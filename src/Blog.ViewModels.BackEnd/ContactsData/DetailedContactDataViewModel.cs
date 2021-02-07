namespace Blog.ViewModels.BackEnd.ContactsData
{
    using Blog.Data.Models;
    using Blog.Infrastructure.AutoMapper;

    public class DetailedContactDataViewModel : ContactDataViewModel, IHaveMapFrom<ContactData>
    {
        public string Message {get; set; } = null!;
    }
}
