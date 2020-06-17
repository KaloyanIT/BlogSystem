namespace Blog.ViewModels.BackEnd.Users
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class UserViewModel : IHaveMapFrom<User>
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
