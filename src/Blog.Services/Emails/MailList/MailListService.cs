namespace Blog.Services.Emails.MailList
{
    using AutoMapper;
    using Data.Repositories.MailLists;

    public class MailListService : IMailListService
    {
        private readonly IMailListRepository _mailListRepository;
        private readonly IMapper _mapper;

        public MailListService(IMailListRepository mailListRepository, IMapper mapper)
        {
            _mailListRepository = mailListRepository;
            _mapper = mapper;
        }
    }
}
