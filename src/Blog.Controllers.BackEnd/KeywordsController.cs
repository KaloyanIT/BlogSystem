namespace Blog.Controllers.BackEnd
{
    using Base;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Keywords;
    using ViewModels.BackEnd.Keywords;

    public class KeywordsController : BackEndController
    {
        private readonly IKeywordService _keywordService;

        public KeywordsController(IKeywordService keywordService, 
            ILogger<KeywordsController> logger) : base(logger)
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
