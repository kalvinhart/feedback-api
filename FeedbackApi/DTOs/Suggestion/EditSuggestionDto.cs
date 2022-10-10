using FeedbackApi.Entities;

namespace FeedbackApi.DTOs.Suggestion
{
    public class EditSuggestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public Status Status { get; set; } = Status.Untracked;
    }
}
