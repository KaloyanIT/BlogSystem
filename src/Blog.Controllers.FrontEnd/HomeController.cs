namespace Blog.Controllers.FrontEnd
{
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using Blog.Infrastructure.Enums;
    using Blog.Infrastructure.Options;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Services.Blog;
    using ViewModels.FrontEnd.Blogs;

    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly SystemOptions _systemOptions;

        public HomeController(IBlogService blogService,
            IOptions<SystemOptions> options,
            IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;

            _systemOptions = options.Value;
        }

        public IActionResult Index(int page = 1)
        {
            var blogs = _blogService.GetAll()
                .Where(x => x.ShowOnHomePage)
                .OrderByDescending(x => x.DateCreated)
                .To<BlogViewModel>()
                .GetPaged(page, 20);

            return View(blogs);
        }

        [Route("tags")]
        public IActionResult Tags(string tagName, int page = 1)
        {
            var blogs = _blogService.GetAll(true, tagName)
                .OrderByDescending(x => x.DateCreated)
                .To<BlogViewModel>()
                .GetPaged(page, 20);

            return View(blogs);
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("cookie-policy")]
        public IActionResult CookiePolicy()
        {
            return View();
        }

        [Route("privacy-policy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [Route("robots.txt")]
        public ContentResult DynamicRobotsFile()
        {
            StringBuilder content = new StringBuilder();
            content.AppendLine("User-agent: *");

            if(_systemOptions.Environment == SystemEnvironments.Development.ToString())
            {
                content.AppendLine("Disallow: /");
            }

            if(_systemOptions.Environment == SystemEnvironments.Production.ToString())
            {
                content.AppendLine("Allow: /");
                content.AppendLine("Disallow: /admin");
                content.AppendLine("Disallow: /login");
                content.AppendLine("Disallow: /register");
            }

            return this.Content(content.ToString(), "text/plain", Encoding.UTF8);
        }
    }
}
