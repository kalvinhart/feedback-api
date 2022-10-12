using FeedbackApi.DTOs.Comment;
using FeedbackApi.Entities;

namespace FeedbackApi.DTOs.Suggestion
{
    public class SuggestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Category Category { get; set; }
        public Status Status { get; set; } = Status.Untracked;
        public int Upvotes { get; set; }
        public int UserId { get; set; }
        public List<CommentDto> Comments { get; set; } = new();
    }
}
