namespace Blog.ViewModels.BackEnd.Users
{
    using System.ComponentModel.DataAnnotations;
    using Blog.Data.Models;
    using Blog.Infrastructure.AutoMapper;

    public class CreateUserViewModel : IHaveMapTo<User>
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
