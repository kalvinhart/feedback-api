using FeedbackApi.DTOs.User;

namespace FeedbackApi.DTOs.Comment
{
    public class PostCommentDto
    {
        public string Content { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public int SuggestionId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
