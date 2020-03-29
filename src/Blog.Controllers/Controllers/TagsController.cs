using Blog.Controllers.ViewModels.Tags;
using Blog.Services.Tags;
using Blog.Services.Tags.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Controllers.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly ITagService tagService;

        public TagsController(ITagService tagService)
        {
            this.tagService = tagService ?? throw new ArgumentNullException("tagServiceInstance", "Tag service is null.");
        }

        public IActionResult Index()
        {
            var tags = this.tagService.GetAll();

            var viewModels = new List<TagViewModel>();

            foreach(var item in tags)
            {
                viewModels.Add(new TagViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    DateCreated = item.DateCreated,
                    DateModified = item.DateModified
                });
            }

            return this.View(viewModels);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagViewModel tagViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(tagViewModel);
            }

            var tagServiceModel = new TagServiceModel();
            tagServiceModel.Name = tagViewModel.Name;

            await this.tagService.Save(tagServiceModel);

            return this.RedirectToAction("Index");
        }
    }
}
