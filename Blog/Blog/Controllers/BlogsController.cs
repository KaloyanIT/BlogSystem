using Blog.Data;
using Blog.Services.Contracts;
using Blog.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class BlogsController : Controller
    {
        private readonly BlogContext _context;
        private readonly IBlogService blogService;

        public BlogsController(BlogContext context, IBlogService blogService)
        {
            this._context = context;
            this.blogService = blogService;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return this.View(await this._context.Blogs.ToListAsync());
        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateCreated,DateModified,Title,Content")] BlogServiceModel blog)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(blog);
            }

            await this.blogService.Create(blog);
          
            return this.RedirectToAction(nameof(Index));
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blog = await this._context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return this.NotFound();
            }
            return this.View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DateCreated,DateModified,Title,Content")] BlogPost blog)
        {
            if (id != blog.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this._context.Update(blog);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BlogExists(blog.Id))
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
