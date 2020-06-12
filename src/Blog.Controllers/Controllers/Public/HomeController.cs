namespace Blog.Controllers.Controllers.Public
{
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Blog;
    using ViewModels.Public.Blogs;

    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public HomeController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAllLatest().Where(x => x.ShowOnHomePage);

            var blogsViewModels = blogs.To<BlogViewModel>().ToList();

            return View(blogsViewModels);
        }

        public ActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public ActionResult BlogPostSummaryPartial()
        {
            return PartialView();
        }
    }
}
