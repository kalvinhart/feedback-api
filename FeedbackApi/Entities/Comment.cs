namespace FeedbackApi.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<CommentReply> Replies { get; set; } = new List<CommentReply>();
        public User User { get; set; } = null!;
        public int SuggestionId { get; set; }
    }

    public class CommentReply
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; } = null!;
        public int CommentId { get; set; }
    }
}
