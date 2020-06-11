namespace Blog.Controllers.BackEnd
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.BackEnd.Tags;
    using Microsoft.AspNetCore.Mvc;
    using Services.Tags;
    using Services.Tags.Models;

    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService), "Tag service is null.");
        }

        public IActionResult Index()
        {
            var tags = _tagService.GetAll();

            var viewModels = new List<TagViewModel>();

            foreach (var item in tags)
            {
                viewModels.Add(new TagViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    DateCreated = item.DateCreated,
                    DateModified = item.DateModified
                });
            }

            return View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagViewModel tagViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(tagViewModel);
            }

            var tagServiceModel = new TagServiceModel();
            tagServiceModel.Name = tagViewModel.Name;

            await _tagService.Save(tagServiceModel);

            return RedirectToAction("Index");
        }
    }
}
