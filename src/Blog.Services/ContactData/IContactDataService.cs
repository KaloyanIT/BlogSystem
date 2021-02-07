namespace Blog.Services.ContactData
{
    using System.Threading.Tasks;
    using Base;
    using Data.Models;
    using ContactData.Models;

    public interface IContactDataService : IService
    {
        Task<ContactData> Create(CreateContactDataServiceModel serviceModel);
    }
}
