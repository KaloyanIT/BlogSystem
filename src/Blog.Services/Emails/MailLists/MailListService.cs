namespace Blog.Services.Emails.MailLists
{
    using System.Linq;
    using AutoMapper;
    using Data.Repositories.MailLists;
    using Data.Models.Emails;

    public class MailListService : IMailListService
    {
        private readonly IMailListRepository _mailListRepository;
        private readonly IMapper _mapper;

        public MailListService(IMailListRepository mailListRepository, IMapper mapper)
        {
            _mailListRepository = mailListRepository;
            _mapper = mapper;
        }

        public IQueryable<MailList> GetAll()
        {
            var result = this._mailListRepository.GetAll();

            return result;
        }
    }
}
