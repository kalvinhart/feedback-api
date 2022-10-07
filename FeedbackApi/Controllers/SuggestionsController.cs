using FeedbackApi.Data;
using FeedbackApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly FeedbackContext _context;

        public SuggestionsController(FeedbackContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all", Name = "GetSuggestions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var suggestions = await _context.Suggestions.ToListAsync();
            return Ok(suggestions);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Suggestion suggestion)
        {
            if (suggestion == null) return BadRequest("No data was received");

            Suggestion newSuggestion = new Suggestion
            {
                Category = suggestion.Category,
                Title = suggestion.Title,
                Description = suggestion.Description,
                UserId = suggestion.UserId,
            };

            var createdSuggestion = await _context.Suggestions.AddAsync(newSuggestion);

            return CreatedAtRoute("GetSuggestions", createdSuggestion);
        }
    }
}
