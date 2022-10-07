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
        [Route("{suggestionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComments(int suggestionId)
        {
            var suggestion = await _context.Suggestions.FindAsync(suggestionId);

            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            var comments = await _context.Comments.Where(c => c.SuggestionId == suggestionId).OrderBy(c => c.CreatedAt).ToListAsync();
            return Ok(comments);
        }
    }
}
