namespace Blog.ViewModels.BackEnd.Users
{
    using Microsoft.AspNetCore.Identity;

    using Infrastructure.AutoMapper;

    public class UserViewModel : IHaveMapFrom<IdentityUser>
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }
    }
}
