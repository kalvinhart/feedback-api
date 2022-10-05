using FeedbackApi.Entities;

namespace FeedbackApi.Data
{
    public static class DbInitializer
    {


        public static void Initialize(FeedbackContext context)
        {
            if (context.Suggestions.Any()) return;

            User admin1 = new User
            {
                Name = "Admin1",
                Role = Role.Admin,
                Username = "admin",
                Email = "admin@test.com",
                Password = "testing123"
            };

            User user1 = new User
            {
                Name = "User1",
                Role = Role.User,
                Username = "user1",
                Email = "user1@test.com",
                Password = "testing123"
            };

            User user2 = new User
            {
                Name = "User2",
                Role = Role.User,
                Username = "user2",
                Email = "user2@test.com",
                Password = "testing123"
            };

            var users = new List<User>
            {
                admin1,
                user1,
            };

            var suggestions = new List<Suggestion>
            {
                new Suggestion
                {
                    Title = "Improve Accessibility",
                    Description = "Making your application more accessible is good.",
                    Category = Category.Enhancement,
                    Comments = new List<Comment>{},
                    Upvotes = 12,
                    User = user1
                },
            };

            var comments = new List<Comment>
            {
                new Comment
                {
                    SuggestionId = 1,
                    Content = "I agree!",
                    User = user2
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            foreach (var suggestion in suggestions)
            {
                context.Suggestions.Add(suggestion);
            }

            foreach (var comment in comments)
            {
                context.Comments.Add(comment);
            }
        }
    }
}
