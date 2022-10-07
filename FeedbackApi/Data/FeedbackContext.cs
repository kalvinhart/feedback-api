using FeedbackApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Suggestion> Suggestions { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<CommentReply> CommentReplies { get; set; } = null!;

    }
}
