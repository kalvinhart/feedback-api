namespace FeedbackApi.Entities
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int Upvotes { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
