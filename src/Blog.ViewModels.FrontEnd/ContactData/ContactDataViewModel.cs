namespace Blog.ViewModels.FrontEnd.ContactData
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.AutoMapper;
    using Services.ContactData.Models;

    public class ContactDataViewModel : IHaveMapTo<CreateContactDataServiceModel>
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Subject { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;

        public string RecaptchaToken {get; set; } = null!;
    }
}
