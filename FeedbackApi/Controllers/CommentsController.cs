using FeedbackApi.Data;
using FeedbackApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly FeedbackContext _context;

        public CommentsController(FeedbackContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{suggestionId}", Name = "GetComments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComments(int suggestionId)
        {
            var suggestion = await _context.Suggestions.FindAsync(suggestionId);

            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            var comments = await _context.Comments.Where(c => c.SuggestionId == suggestionId).OrderBy(c => c.CreatedAt).ToListAsync();
            return Ok(comments);
        }

        [HttpPost]
        [Route("{suggestionId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostComment(int suggestionId, Comment comment)
        {
            var suggestion = await _context.Suggestions.FindAsync(suggestionId);

            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            var newComment = new Comment
            {
                SuggestionId = suggestionId,
                Content = comment.Content,
                Username = comment.Username,
                AuthorName = comment.AuthorName
            };

            await _context.Comments.AddAsync(newComment);
            return CreatedAtRoute("GetComments", newComment);
        }

        [HttpPost]
        [Route("{suggestionId}/{commentId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostReply(int suggestionId, int commentId, Comment reply)
        {
            if (commentId != reply.ParentCommentId) return BadRequest("Comment IDs do not match.");

            var suggestion = await _context.Suggestions.FindAsync(suggestionId);
            var comment = await _context.Comments.FindAsync(commentId);

            if (suggestion == null || comment == null) return NotFound("Suggestion or Comment ID does not exist.");

            var newReply = new Comment
            {
                ParentCommentId = reply.ParentCommentId,
                Content = reply.Content,
                Username = reply.Username,
                AuthorName = reply.AuthorName,
            };

            await _context.Comments.AddAsync(newReply);
            return CreatedAtRoute("GetComments", newReply);
        }
    }
}
