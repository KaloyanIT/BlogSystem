namespace Blog.Controllers.BackEnd.Emails
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Blog.ViewModels.BackEnd.Emails.MailLists;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Emails.MailLists;
    using Services.Emails.MailLists.Models;

    [Area("Admin")]
    [Route("emails/mailLists")]
    public class MailListsController : BackEndController
    {
        private readonly IMailListService _mailListService;

        public MailListsController(IMailListService mailListService,
            ILogger<MailListsController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _mailListService = mailListService;
        }

        [Route("index")]
        public IActionResult Index(int page = 1)
        {
            var mailLists = _mailListService
                    .GetAll()
                    .To<MailListViewModel>()
                    .GetPaged(page, this.MaxPageSize);

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
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var serviceModel = Mapper.Map<CreateMailListServiceModel>(viewModel);

            await _mailListService.Create(serviceModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var item = await _mailListService.GetById(id.Value);

            if (item == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<EditMailListViewModel>(item);

            return View(viewModel);
        }

        [HttpPost]
        [Route("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditMailListViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var serviceModel = Mapper.Map<EditMailListServiceModel>(viewModel);

            await _mailListService.Edit(serviceModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            await _mailListService.Delete(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
