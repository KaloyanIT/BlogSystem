namespace Blog.Services.Emails.MailLists
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models.Emails;
    using Data.Repositories.MailLists;
    using Microsoft.Extensions.Logging;
    using Models;

    public class MailListService : BaseService, IMailListService
    {
        private readonly IMailListRepository _mailListRepository;

        public MailListService(IMailListRepository mailListRepository,
            IMapper mapper,
            ILogger<MailListService> logger) : base(mapper, logger)
        {
            _mailListRepository = mailListRepository;
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
                return;
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
