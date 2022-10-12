namespace FeedbackApi.Entities
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Category Category { get; set; }
        public Status Status { get; set; } = Status.Untracked;
        public int Upvotes { get; set; }
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

    public enum Category
    {
        UI,
        UX,
        Enhancement,
        Bug,
        Feature
    }

    public enum Status
    {
        Untracked,
        Planned,
        InProgress,
        Live
    }
}
