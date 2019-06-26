using AutoMapper;
using Blog.Core.ViewModels.Blogs;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

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
            var blogs = this.blogService.GetAll().ToList();
            IDictionary<int, ICollection<BlogViewModel>> blogViewModels = new Dictionary<int, ICollection<BlogViewModel>>();
            int row = 0;

            for(int i = 0; i < blogs.Count; i++)
            {
                if(i == 0)
                {
                    blogViewModels.Add(row, new List<BlogViewModel>());
                }

                if (i % 3 == 0 && i != 0)
                {
                    row++;
                    blogViewModels.Add(row, new List<BlogViewModel>());
                }

                var currBlogViewModel = this.mapper.Map<BlogViewModel>(blogs[i]);

                blogViewModels[row].Add(currBlogViewModel);
            }        

            return this.View(blogViewModels);
        }

        public ActionResult BlogPostSummaryPartial()
        {
            return this.PartialView();
        }
    }
}
