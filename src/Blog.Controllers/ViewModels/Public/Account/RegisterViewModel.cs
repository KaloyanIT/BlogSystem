namespace Blog.Controllers.ViewModels.Public.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
