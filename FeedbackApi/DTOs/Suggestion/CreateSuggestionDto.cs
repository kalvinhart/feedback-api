namespace FeedbackApi.DTOs.Suggestion
{
    public class CreateSuggestionDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int UserId { get; set; }
    }
}
