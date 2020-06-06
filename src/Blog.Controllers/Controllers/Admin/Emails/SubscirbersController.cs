namespace Blog.Controllers.Controllers.Admin.Emails
{
    using Blog.Services.Emails.Subscribers;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Route("emails/subscribers")]
    public class SubscirbersController : Controller
    {
        private readonly ISubscriberService _subscriberService;

        public SubscirbersController(ISubscriberService subscriberService)
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
