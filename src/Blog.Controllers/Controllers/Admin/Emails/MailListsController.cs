namespace Blog.Controllers.Controllers.Admin.Emails
{
    using Blog.Services.Emails.MailList;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Route("emails/mailLists")]
    public class MailListsController : Controller
    {
        private readonly IMailListService _mailListService;

        public MailListsController(IMailListService mailListService)
        {
            _mailListService = mailListService;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return this.View();
        }

        [Route("create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [Route("edit")]
        public IActionResult Edit()
        {
            return this.View();
        }
    }
}
