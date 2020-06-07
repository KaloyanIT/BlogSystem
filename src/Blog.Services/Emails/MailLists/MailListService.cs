namespace Blog.Services.Emails.MailLists
{
    using System.Linq;
    using AutoMapper;
    using Data.Repositories.MailLists;
    using Data.Models.Emails;
    using Models;
    using System.Threading.Tasks;
    using System;

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

            if(item == null)
            {
                //throw
            }

            await _mailListRepository.Delete(item);
        }

        public IQueryable<MailList> GetAll()
        {
            var result = this._mailListRepository.GetAll();

            return result;
        }
    }
}
