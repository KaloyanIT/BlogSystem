﻿namespace Blog.Controllers.BackEnd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.Data.Base.Extensions;
    using Blog.ViewModels.BackEnd.Blogs;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Services.Blog;
    using Services.Blog.Models;
    using Services.Users;

    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        private const int MaxPageSize = 10;

        public BlogsController(IBlogService blogService, IUserService userService, IMapper mapper)
        {
            _blogService = blogService;
            _userService = userService;
            _mapper = mapper;
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

            var userId = await _userService.GetIdByUsername(User.Identity.Name!);

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

                    var userId = await _userService.GetIdByUsername(User.Identity.Name!);

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

            var blog = await _blogService.GetById(id);

            var viewModel = _mapper.Map<DetailedBlogViewModel>(blog);

            return View(viewModel);
        }

        //POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _blogService.Delete(id);


            return RedirectToAction(nameof(Index));
        }

        //private bool BlogExists(Guid id)
        //{
        //    return _context.Blogs.Any(e => e.Id == id);
        //}
    }
}