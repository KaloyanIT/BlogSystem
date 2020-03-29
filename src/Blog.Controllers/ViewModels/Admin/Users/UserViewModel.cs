namespace Blog.Controllers.ViewModels.Admin.Users
{
    using Microsoft.AspNetCore.Identity;

    using Infrastructure.AutoMapper;

    public class UserViewModel : IHaveMapFrom<IdentityUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
