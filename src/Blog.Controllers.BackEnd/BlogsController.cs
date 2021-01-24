namespace Blog.Controllers.BackEnd
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Blog.Data.Base.Extensions;
    using Blog.Services.Meta.OpenGraphs;
    using Blog.Services.Meta.OpenGraphs.Models;
    using Blog.Services.Tags;
    using Blog.ViewModels.BackEnd.Blogs;
    using Blog.ViewModels.BackEnd.Meta.OpenGraphs;
    using Blog.ViewModels.BackEnd.Tags;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Services.Blog;
    using Services.Blog.Models;
    using Services.Users;

    [Area("Admin")]
    public class BlogsController : BackEndController
    {
        private readonly IBlogService _blogService;
        private readonly IOpenGraphService _openGraphService;
        private readonly ITagService _tagService;
        private readonly IUserService _userService;

        public BlogsController(IBlogService blogService,
            ILogger<BlogsController> logger,
            IOpenGraphService openGraphService,
            ITagService tagService,
            IUserService userService,
            IMapper mapper) : base(logger, mapper)
        {
            _blogService = blogService;
            _openGraphService = openGraphService;
            _tagService = tagService;
            _userService = userService;
        }

        public IActionResult Index(int page = 1)
        {
            var blogs = _blogService.GetAll()
                .OrderByDescending(x => x.DateCreated)
                .To<BlogViewModel>()
                .GetPaged(page, MaxPageSize);

            return View(blogs);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blogService.GetById(id);

            if (blog == null)
            {
                return NotFound();
            }

            var blogViewModel = Mapper.Map<DetailedBlogViewModel>(blog);

            blogViewModel.OpenGraph = await this.GetOpenGraphViewModel(blog.Id);

            return View(blogViewModel);
        }

        // GET: Blogs/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateBlogViewModel();

            var tags = await _tagService.GetAll()
               .To<TagViewModel>()
               .ToListAsync();

            viewModel.TagsSelectListItems = tags.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            })
            .ToList();

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogViewModel blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            //Add validation
            var serviceModel = Mapper.Map<CreateBlogViewModel, CreateBlogServiceModel>(blog);

            var userId = await _userService.GetIdByUsername(User.Identity!.Name!);

            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/account/login");
            }

            serviceModel.UserId = userId;

            var blogPost = await _blogService.Create(serviceModel);

            var openGraph = Mapper.Map<CreateOpenGraphServiceModel>(blog.OpenGraphViewModel);

            await _openGraphService.Create(openGraph, blogPost.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blogService.GetById(id);

            if (blog == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<EditBlogViewModel>(blog);

            viewModel.OpenGraphViewModel = await this.GetOpenGraphViewModel(blog.Id);

            return View(viewModel);
        }

        private async Task<OpenGraphViewModel> GetOpenGraphViewModel(Guid attachedItemId)
        {
            var openGraph = await _openGraphService.GetByAttachedItemId(attachedItemId);

            if (openGraph == null)
            {
                return new OpenGraphViewModel(attachedItemId);
            }

            var openGraphViewModel = Mapper.Map<OpenGraphViewModel>(openGraph);

            return openGraphViewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditBlogViewModel blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var serviceModel = Mapper.Map<BlogServiceModel>(blog);

                    var userId = await _userService.GetIdByUsername(User.Identity!.Name!);

                    if (string.IsNullOrEmpty(userId))
                    {
                        return Redirect("/account/login");
                    }

                    serviceModel.UserId = Guid.Parse(userId);

                    await _blogService.Edit(serviceModel);

                    var openGraphServiceModel = Mapper.Map<EditOpenGraphServiceModel>(blog.OpenGraphViewModel);

                    await _openGraphService.Edit(openGraphServiceModel, blog.OpenGraphViewModel.Id);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _blogService.Exists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blogService.GetById(id);
            var openGraph = await _openGraphService.GetByAttachedItemId(id.Value);

            var viewModel = Mapper.Map<DetailedBlogViewModel>(blog);
            viewModel.OpenGraph = Mapper.Map<OpenGraphViewModel>(openGraph);

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _blogService.Delete(id);
            await _openGraphService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
