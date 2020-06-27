namespace Blog.Controllers.FrontEnd
{
    using System.Linq;
    using AutoMapper;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Blog;
    using ViewModels.FrontEnd.Blogs;

    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public HomeController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            var blogs = _blogService.GetAll()
                .Where(x => x.ShowOnHomePage)
                .To<BlogViewModel>()
                .GetPaged(page, 10);


            return View(blogs);
        }

        [Route("about")]
        public ActionResult About()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
