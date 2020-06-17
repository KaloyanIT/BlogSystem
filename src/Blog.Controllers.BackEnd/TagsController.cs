namespace Blog.Controllers.BackEnd
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Tags;
    using Services.Tags.Models;
    using ViewModels.BackEnd.Tags;

    [Area("Admin")]
    public class TagsController : BackEndController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService,
            ILogger<TagsController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService), "Tag service is null.");
        }

        public IActionResult Index(int page = 1)
        {
            var viewModels = _tagService.GetAll()
                .To<TagViewModel>()
                .GetPaged(page, 10);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTagViewModel tagViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(tagViewModel);
            }

            var tagServiceModel = Mapper.Map<CreateTagServiceModel>(tagViewModel);            

            await _tagService.Create(tagServiceModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _tagService.GetById(id);

            if (tag == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<EditTagViewModel>(tag);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditTagViewModel tagViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            if(!ModelState.IsValid)
            {
                return this.View(tagViewModel);
            }

            var editServiceModel = Mapper.Map<EditTagServiceModel>(tagViewModel);

            await _tagService.Edit(editServiceModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if(!id.HasValue)
            {
                return NotFound();
            }

            var tag = await _tagService.GetById(id);

            var viewModel = Mapper.Map<TagViewModel>(tag);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tagService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
