namespace Blog.Services.ContactData
{
    using System.Threading.Tasks;
    using Base;
    using Data.Models;
    using ContactData.Models;
    using System.Linq;
    using System;

    public interface IContactDataService : IService
    {
        Task<ContactData> Create(CreateContactDataServiceModel serviceModel);

        IQueryable<ContactData> GetAll();
        Task<ContactData?> GetById(Guid id);
    }
}
