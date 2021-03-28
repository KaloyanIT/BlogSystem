﻿namespace Blog.Controllers.FrontEnd
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
    }
}
