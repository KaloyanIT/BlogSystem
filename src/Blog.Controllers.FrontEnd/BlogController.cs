namespace Blog.Controllers.FrontEnd
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.ViewModels.FrontEnd.Blogs;
    using Microsoft.AspNetCore.Mvc;

    using Services.Blog;

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction("OlderPosts");
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var blogPost = await _blogService.GetById(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            var detailedBlogPost = _mapper.Map<DetailedBlogPostViewModel>(blogPost);

            return View(detailedBlogPost);
        }

        public IActionResult OlderPosts()
        {
            var blogs = _blogService.GetAllLatest();


            return View();
        }
    }
}