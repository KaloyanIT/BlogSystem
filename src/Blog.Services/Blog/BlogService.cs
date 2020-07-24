﻿namespace Blog.Services.Blog
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models;
    using Data.Repositories.Blog;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Models;

    public class BlogService : BaseService, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository, 
            IMapper mapper,
            ILogger<BlogService> logger) : base(mapper, logger)

        {
            _blogRepository = blogRepository;
        }


        public async Task<BlogPost> Create(CreateBlogServiceModel serviceModel)
        {
            if(serviceModel == null)
            {
                throw new ArgumentNullException(nameof(serviceModel), "Service model can not be null!");
            }

            var blogPost = new BlogPost(serviceModel.Title, serviceModel.Content, serviceModel.Summary, serviceModel.UserId, serviceModel.ShowOnHomePage);

            await _blogRepository.Save(blogPost);

            return blogPost;
        }

        public async Task Delete(Guid? id)
        {
            if(!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id), "Id can not be null!");
            }

            var blog = await this.GetById(id);

            await _blogRepository.Delete(blog);
        }

        public async Task<BlogServiceModel> Edit(BlogServiceModel blogServiceModel)
        {
            var blog = await _blogRepository.GetById(blogServiceModel.Id);

            Mapper.Map(blogServiceModel, blog);

            await _blogRepository.Save(blog);

            return blogServiceModel;
        }

        public async Task<bool> Exists(Guid? id)
        {
            if (!id.HasValue)
            {
                return false;
            }

            var result = await GetAll().AnyAsync(x => x.Id == id);

            return result;
        }

        public IQueryable<BlogPost> GetAll()
        {
            var result = _blogRepository.GetAll();

            return result;
        }

        public IQueryable<BlogPost> GetAllLatest()
        {
            var result = GetAll().OrderByDescending(x => x.DateCreated);

            return result;
        }

        public async Task<BlogPost?> GetById(Guid? id)
        {
            if (!id.HasValue)
            {
                return null!;
            }

            var result = await _blogRepository.GetById(id.Value);

            return result;
        }
    }
}
