using FeedbackApi.DTOs.User;

namespace FeedbackApi.DTOs.Comment
{
    public class PostReplyDto
    {
        public string Content { get; set; } = null!;
        public UserDetailDto User { get; set; } = null!;
        public int CommentId { get; set; }
    }
}
