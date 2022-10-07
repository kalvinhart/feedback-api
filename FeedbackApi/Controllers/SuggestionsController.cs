using AutoMapper;
using FeedbackApi.Data;
using FeedbackApi.DTOs.Suggestion;
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
        private readonly IMapper _mapper;

        public SuggestionsController(FeedbackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all", Name = "GetSuggestions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var suggestions = await _context.Suggestions.ToListAsync();
            return Ok(suggestions);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var suggestion = await _context.Suggestions
                .Include(s => s.Comments)
                .ThenInclude(c => c.Replies)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            return Ok(suggestion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateSuggestionDto suggestionDto)
        {
            if (suggestionDto == null) return BadRequest("No data was received");

            var newSuggestion = _mapper.Map<Suggestion>(suggestionDto);

            var createdSuggestion = await _context.Suggestions.AddAsync(newSuggestion);

            return CreatedAtRoute("GetSuggestions", createdSuggestion);
        }
    }
}
