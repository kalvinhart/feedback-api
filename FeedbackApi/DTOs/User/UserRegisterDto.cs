namespace FeedbackApi.DTOs.User
{
    public class UserRegisterDto : UserLoginDto
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
