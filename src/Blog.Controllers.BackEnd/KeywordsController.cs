namespace Blog.Controllers.BackEnd
{
    using System;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Keywords;
    using Services.Keywords.Models;
    using ViewModels.BackEnd.Keywords;

    [Area("Admin")]
    public class KeywordsController : BackEndController
    {
        private readonly IKeywordService _keywordService;

        public KeywordsController(IKeywordService keywordService,
            ILogger<KeywordsController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _keywordService = keywordService;
        }

        public IActionResult Index(int page = 1)
        {
            var viewModels = _keywordService
                .GetAll()
                .To<KeywordViewModel>()
                .GetPaged(page, this.MaxPageSize);


            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateKeywordViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateKeywordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var serviceModel = Mapper.Map<CreateKeywordServiceModel>(viewModel);

            await _keywordService.Create(serviceModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _keywordService.GetById(id);

            var viewModel = Mapper.Map<EditKeywordViewModel>(item);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditKeywordViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            var serviceModel = Mapper.Map<EditKeywordServiceModel>(viewModel);

            await _keywordService.Edit(serviceModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _keywordService.GetById(id);

            var viewModel = Mapper.Map<DetailedKeywordViewModel>(item);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _keywordService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
