namespace Blog.ViewModels.FrontEnd.ContactData
{
    using Infrastructure.AutoMapper;
    using Services.ContactData.Models;

    public class ContactDataViewModel : IHaveMapTo<CreateContactDataServiceModel>
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
