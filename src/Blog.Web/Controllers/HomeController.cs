using AutoMapper;
using Blog.Controllers.ViewModels.Blogs;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Blog.Infrastructure.Extensions;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IMapper mapper;

        public HomeController(IBlogService blogService, IMapper mapper)
        {
            this.blogService = blogService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = this.blogService.GetAllLatest();

            var blogsViewModels = blogs.To<BlogViewModel>().ToList();           

            return this.View(blogsViewModels);
        }

        public ActionResult About()
        {
            return this.View();
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        public ActionResult BlogPostSummaryPartial()
        {
            return this.PartialView();
        }
    }
}
