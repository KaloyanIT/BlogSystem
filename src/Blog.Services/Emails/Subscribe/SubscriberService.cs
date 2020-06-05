namespace Blog.Services.Emails.Subscribe
{
    using AutoMapper;

    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;

        public SubscriberService(ISubscriberService subscriberService, IMapper mapper)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
        }
    }
}
