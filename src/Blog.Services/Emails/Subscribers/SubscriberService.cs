namespace Blog.Services.Emails.Subscribers
{
    using AutoMapper;
    using Base;
    using Microsoft.Extensions.Logging;

    public class SubscriberService : BaseService, ISubscriberService
    {
        public SubscriberService(IMapper mapper,
            ILogger<SubscriberService> logger) : base(mapper, logger)
        {
        }
    }
}
