using AutoMapper;
using FeedbackApi.Data;
using FeedbackApi.DTOs.Comment;
using FeedbackApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly FeedbackContext _context;
        private readonly IMapper _mapper;

        public CommentsController(FeedbackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetComments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComments(int id)
        {
            var suggestion = await _context.Suggestions.FindAsync(id);

            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            var comments = await _context.Comments.Where(c => c.SuggestionId == id).OrderBy(c => c.CreatedAt).ToListAsync();

            var commentsResponse = new List<CommentDto>();

            foreach (var comment in comments)
            {
                commentsResponse.Add(_mapper.Map<CommentDto>(comment));
            }

            return Ok(commentsResponse);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostComment(PostCommentDto commentDto)
        {
            var suggestion = await _context.Suggestions.FirstOrDefaultAsync(c => c.Id == commentDto.SuggestionId);

            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            var newComment = _mapper.Map<Comment>(commentDto);

            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComments), new { id = commentDto.SuggestionId }, commentDto);
        }
    }
}
