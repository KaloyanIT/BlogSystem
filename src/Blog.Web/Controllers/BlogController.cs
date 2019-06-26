using System;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Services.Contracts;
using Blog.Web.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IMapper mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            this.blogService = blogService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogPost = await this.blogService.GetById(id);

            if(blogPost == null)
            {
                return this.NotFound();
            }

            var detailedBlogPost = this.mapper.Map<DetailedBlogPostViewModel>(blogPost);

            return this.View(detailedBlogPost);
        }
    }
}