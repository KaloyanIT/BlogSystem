namespace Blog.Controllers.Controllers.Admin.Emails
{
    using AutoMapper;
    using Blog.Controllers.ViewModels.Admin.Emails.MailLists;
    using Blog.Data.Extensions;
    using Blog.Infrastructure.Extensions;
    using Blog.Services.Emails.MailLists;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Route("emails/mailLists")]
    public class MailListsController : Controller
    {
        private readonly IMailListService _mailListService;
        private readonly IMapper _mapper;

        public MailListsController(IMailListService mailListService, IMapper mapper)
        {
            _mailListService = mailListService;
            _mapper = mapper;
        }

        [Route("index")]
        public IActionResult Index(int page = 1)
        {
            var mailLists = _mailListService.GetAll().To<MailListViewModel>().GetPaged(page, 10);

            return View(mailLists);
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
