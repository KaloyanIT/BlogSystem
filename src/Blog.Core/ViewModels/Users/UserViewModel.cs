using Blog.Infrastructure.AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Blog.Core.ViewModels.Users
{
    public class UserViewModel : IHaveMapFrom<IdentityUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
