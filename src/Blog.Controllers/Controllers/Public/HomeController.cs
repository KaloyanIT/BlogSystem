namespace Blog.Controllers.Controllers.Public
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure.Extensions;
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
            var blogs = _blogService.GetAllLatest();

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
