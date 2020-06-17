namespace Blog.Controllers.BackEnd
{
    using AutoMapper;
    using Base;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Keywords;
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
    }
}
