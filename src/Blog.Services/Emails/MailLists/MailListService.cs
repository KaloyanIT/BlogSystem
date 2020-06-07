namespace Blog.Services.Emails.MailLists
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Models.Emails;
    using Data.Repositories.MailLists;
    using Models;

    public class MailListService : IMailListService
    {
        private readonly IMailListRepository _mailListRepository;
        private readonly IMapper _mapper;

        public MailListService(IMailListRepository mailListRepository, IMapper mapper)
        {
            _mailListRepository = mailListRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateMailListServiceModel serviceModel)
        {
            var mailList = new MailList(serviceModel.Name, serviceModel.Description);

            await _mailListRepository.Save(mailList);
        }

        public async Task Delete(Guid id)
        {
            var item = await _mailListRepository.GetById(id);


            if (item == null)
            {
                //throw
            }

            item.Delete();
            await _mailListRepository.Delete(item);
        }

        public async Task Edit(EditMailListServiceModel serviceModel)
        {
            var item = await GetById(serviceModel.Id);

            item.Edit(serviceModel.Name, serviceModel.Description);

            await _mailListRepository.Save(item);
        }

        public IQueryable<MailList> GetAll()
        {
            var result = _mailListRepository.GetAll();

            return result;
        }

        public Task<MailList> GetById(Guid id)
        {
            var item = _mailListRepository.GetById(id);

            return item;
        }
    }
}
