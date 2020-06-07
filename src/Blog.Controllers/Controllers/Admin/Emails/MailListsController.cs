namespace Blog.Controllers.Controllers.Admin.Emails
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.Controllers.ViewModels.Admin.Emails.MailLists;
    using Blog.Data.Extensions;
    using Blog.Infrastructure.Extensions;
    using Blog.Services.Emails.MailLists;
    using Blog.Services.Emails.MailLists.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMailListViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var serviceModel = _mapper.Map<CreateMailListServiceModel>(viewModel);

            await _mailListService.Create(serviceModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [Route("delete")]
        public IActionResult Delete(Guid? id)
        {
            if(!id.HasValue)
            {
                return NotFound();
            }

            _mailListService.Delete(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
