using AutoMapper;
using Blog.Core.ViewModels.Blogs;
using Blog.Data;
using Blog.Data.Models;
using Blog.Services.Contracts;
using Blog.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly BlogContext _context;
        private readonly IBlogService blogService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public BlogsController(BlogContext context, IBlogService blogService, IUserService userService, IMapper mapper)
        {
            this._context = context;
            this.blogService = blogService;
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new List<BlogViewModel>();
            var blogs = this.blogService.GetAll().OrderByDescending(x => x.DateCreated);

            foreach (var blog in blogs)
            {
                model.Add(this.mapper.Map<BlogViewModel>(blog));
            }

            return this.View(model);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blog = await this.blogService.GetById(id);

            if (blog == null)
            {
                return this.NotFound();
            }

            var blogViewModel = this.mapper.Map<DetailedBlogViewModel>(blog);

            return this.View(blogViewModel);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return this.View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogViewModel blog)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(blog);
            }

            //Add validation
            var serviceModel = this.mapper.Map<CreateBlogViewModel, CreateBlogServiceModel>(blog);

            var userId = await this.userService.GetIdByUsername(this.User.Identity.Name);

            if (string.IsNullOrEmpty(userId))
            {
                return this.Redirect("/account/login");
            }

            serviceModel.UserId = Guid.Parse(userId);

            await this.blogService.Create(serviceModel);

            return this.RedirectToAction(nameof(Index));
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blog = await this.blogService.GetById(id);

            if (blog == null)
            {
                return this.NotFound();
            }

            var viewModel = this.mapper.Map<EditBlogViewModel>(blog);

            return this.View(viewModel);
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
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    var serviceModel = this.mapper.Map<BlogServiceModel>(blog);

                    var userId = await this.userService.GetIdByUsername(this.User.Identity.Name);

                    if (string.IsNullOrEmpty(userId))
                    {
                        return this.Redirect("/account/login");
                    }

                    serviceModel.UserId = Guid.Parse(userId);

                    await this.blogService.Edit(serviceModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.blogService.Exists(id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(Index));
            }

            return this.View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blog = await this._context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return this.NotFound();
            }

            return this.View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var blog = await this._context.Blogs.FindAsync(id);
            this._context.Blogs.Remove(blog);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

        private bool BlogExists(Guid id)
        {
            return this._context.Blogs.Any(e => e.Id == id);
        }
    }
}
