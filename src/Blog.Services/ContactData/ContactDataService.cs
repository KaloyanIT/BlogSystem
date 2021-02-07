namespace Blog.Services.ContactData
{
    using System.Threading.Tasks;
    using Data.Repositories.ContactData;
    using Data.Models;
    using ContactData.Models;
    using System;
    using System.Linq;

    public class ContactDataService : IContactDataService
    {
        private readonly IContactDataRepository _contactDataRepository;

        public ContactDataService(IContactDataRepository contactDataRepository)
        {
            _contactDataRepository = contactDataRepository;
        }

        public async Task<ContactData> Create(CreateContactDataServiceModel serviceModel)
        {
            if (serviceModel == null)
            {
                throw new ArgumentNullException(nameof(serviceModel), "Service model can not be null!");
            }

            var contactData = new ContactData(serviceModel.Name, serviceModel.Subject, serviceModel.Email, serviceModel.Message);

            await _contactDataRepository.Save(contactData);

            return contactData;
        }

        public IQueryable<ContactData> GetAll()
        {
            var result = _contactDataRepository.GetAll();

            return result;
        }

        public async Task<ContactData?> GetById(Guid id)
        {
            var result = await _contactDataRepository.GetById(id);

            return result;
        }
    }
}
