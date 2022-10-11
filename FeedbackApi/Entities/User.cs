using Microsoft.AspNetCore.Identity;

namespace FeedbackApi.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = null!;
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum Role
    {
        User,
        Admin,
    }
}
