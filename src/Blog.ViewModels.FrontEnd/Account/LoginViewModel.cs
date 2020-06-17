namespace Blog.ViewModels.FrontEnd.Account
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
