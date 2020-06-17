namespace Blog.Controllers.BackEnd.Emails
{
    using AutoMapper;
    using Base;
    using Blog.Services.Emails.Subscribers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Area("Admin")]
    [Route("emails/subscribers")]
    public class SubscirbersController : BackEndController
    {
        private readonly ISubscriberService _subscriberService;

        public SubscirbersController(ISubscriberService subscriberService, 
            ILogger<SubscirbersController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _subscriberService = subscriberService;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("edit")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
