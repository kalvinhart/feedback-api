using FeedbackApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Data
{
    public class FeedbackContext : IdentityDbContext<User, UserRole, int>
    {
        public FeedbackContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Suggestion> Suggestions { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>()
                .HasData(
                    new UserRole { Id = 1, Name = "User", NormalizedName = "USER" },
                    new UserRole { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
                );
        }
    }
}
