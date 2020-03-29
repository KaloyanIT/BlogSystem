namespace Blog.Controllers.Controllers.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Infrastructure.Extensions;
    using Services.Blog;
    using Services.Blog.Models;
    using Services.User;
    using ViewModels.Admin.Blogs;

    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly BlogContext _context;
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public BlogsController(BlogContext context, IBlogService blogService, IUserService userService, IMapper mapper)
        {
            _context = context;
            _blogService = blogService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new List<BlogViewModel>();
            var blogs = await _blogService.GetAll()
                .OrderByDescending(x => x.DateCreated)
                .To<BlogViewModel>()
                .ToListAsync();

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

            var blogViewModel = _mapper.Map<DetailedBlogViewModel>(blog);

            return View(blogViewModel);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
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
            var serviceModel = _mapper.Map<CreateBlogViewModel, CreateBlogServiceModel>(blog);

            var userId = await _userService.GetIdByUsername(User.Identity.Name);

            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/account/login");
            }

            serviceModel.UserId = userId;

            await _blogService.Create(serviceModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: Blogs/Edit/5
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

            var viewModel = _mapper.Map<EditBlogViewModel>(blog);

            return View(viewModel);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    var serviceModel = _mapper.Map<BlogServiceModel>(blog);

                    var userId = await _userService.GetIdByUsername(User.Identity.Name);

                    if (string.IsNullOrEmpty(userId))
                    {
                        return Redirect("/account/login");
                    }

                    serviceModel.UserId = Guid.Parse(userId);

                    await _blogService.Edit(serviceModel);
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

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(Guid id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
