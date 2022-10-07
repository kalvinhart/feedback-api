namespace FeedbackApi.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Comment> Replies { get; set; } = new List<Comment>();
        public User User { get; set; } = null!;
        public int SuggestionId { get; set; }
    }
}
