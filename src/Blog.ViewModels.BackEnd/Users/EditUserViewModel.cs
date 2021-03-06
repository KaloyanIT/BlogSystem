﻿namespace Blog.ViewModels.BackEnd.Users
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Services.Users.Models;

    public class EditUserViewModel : IHaveMapTo<EditUserServiceModel>, IHaveMapFrom<User>
    {
        public string Id { get; set; } = null!;

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = null!;

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = null!;

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
