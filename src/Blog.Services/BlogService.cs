using AutoMapper;
using Blog.Data;
using Blog.Data.Models;
using Blog.Data.Repositories.Blog;
using Blog.Services.Contracts;
using Blog.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            this.blogRepository = blogRepository;
            this.mapper = mapper;
        }


        public async Task Create(CreateBlogServiceModel blogServiceModel)
        {
            var blogPost = this.mapper.Map<BlogPost>(blogServiceModel);

            await this.blogRepository.Save(blogPost);           
        }

        public async Task<BlogServiceModel> Edit(BlogServiceModel blogServiceModel)
        {
            var blog = this.mapper.Map<BlogPost>(blogServiceModel);

            await this.blogRepository.Save(blog);

            return blogServiceModel;
        }

        public async Task<bool> Exists(Guid? id)
        {
            if(!id.HasValue)
            {
                return false;
            }

            var result = await this.GetAll().AnyAsync(x => x.Id == id);

            return result;
        }

        public IQueryable<BlogPost> GetAll()
        {
            var result = this.blogRepository.GetAll();

            return result;
        }

        public IQueryable<BlogPost> GetAllLatest()
        {
            var result = this.GetAll().OrderByDescending(x => x.DateCreated);

            return result;
        }

        public async Task<BlogPost> GetById(Guid? id)
        {
            if(!id.HasValue)
            {
                return null;
            }

            var result = await this.blogRepository.GetById(id.Value);

            return result;
        }
    }
}
