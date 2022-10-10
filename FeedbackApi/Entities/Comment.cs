namespace FeedbackApi.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int SuggestionId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
