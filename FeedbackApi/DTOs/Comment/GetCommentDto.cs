using FeedbackApi.DTOs.User;
using FeedbackApi.Entities;

namespace FeedbackApi.DTOs.Comment
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Username { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public int SuggestionId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
