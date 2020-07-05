namespace Blog.Services.Emails.Subscribers
{
    using AutoMapper;
    using Base;
    using Microsoft.Extensions.Logging;

    public class SubscriberService : BaseService, ISubscriberService
    {
        private readonly ISubscriberService _subscriberService;

        public SubscriberService(ISubscriberService subscriberService,
            IMapper mapper,
            ILogger<SubscriberService> logger) : base(mapper, logger)
        {
            _subscriberService = subscriberService;
        }
    }
}
