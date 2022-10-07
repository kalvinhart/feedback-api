using FeedbackApi.DTOs.User;

namespace FeedbackApi.DTOs.Comment
{
    public class PostCommentDto
    {
        public string Content { get; set; } = null!;
        public UserDetailDto User { get; set; } = null!;
        public int SuggestionId { get; set; }
    }
}
