using AutoMapper;
using FeedbackApi.Data;
using FeedbackApi.DTOs.Suggestion;
using FeedbackApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly FeedbackContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public SuggestionsController(FeedbackContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
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
            var suggestion = await _context.Suggestions.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);

            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            return Ok(_mapper.Map<SuggestionDto>(suggestion));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateSuggestionDto suggestionDto)
        {
            if (suggestionDto == null) return BadRequest("No data was received");

            var newSuggestion = _mapper.Map<Suggestion>(suggestionDto);

            await _context.Suggestions.AddAsync(newSuggestion);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetSuggestions", newSuggestion);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(EditSuggestionDto suggestionDto)
        {
            if (suggestionDto == null) return BadRequest("No data was received");

            var user = await _userManager.FindByNameAsync(User.Identity!.Name);

            var suggestion = await _context.Suggestions.FirstOrDefaultAsync(s => s.Id == suggestionDto.Id);
            if (suggestion == null) return NotFound("Suggestion ID does not exist.");

            if (user.Id != suggestion.UserId) return Forbid();

            var newSuggestion = _mapper.Map(suggestionDto, suggestion);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
