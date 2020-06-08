namespace Blog.Controllers.Controllers.Admin.Emails
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Emails.MailLists;
    using Services.Emails.MailLists.Models;
    using ViewModels.Admin.Emails.MailLists;

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
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var serviceModel = _mapper.Map<CreateMailListServiceModel>(viewModel);

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

            var viewModel = _mapper.Map<EditMailListViewModel>(item);

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

            var serviceModel = _mapper.Map<EditMailListServiceModel>(viewModel);

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
