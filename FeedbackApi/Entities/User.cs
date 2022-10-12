using Microsoft.AspNetCore.Identity;

namespace FeedbackApi.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
