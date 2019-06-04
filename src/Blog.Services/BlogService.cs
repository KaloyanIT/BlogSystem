using AutoMapper;
using Blog.Data;
using Blog.Data.Models;
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
        private readonly BlogContext blogContext;
        private readonly IMapper mapper;

        public BlogService(BlogContext blogContext, IMapper mapper)
        {
            this.blogContext = blogContext;
            this.mapper = mapper;
        }


        public async Task Create(CreateBlogServiceModel blogServiceModel)
        {
            var blogPost = this.mapper.Map<BlogPost>(blogServiceModel);

            blogPost.DateCreated = DateTime.Now;
            blogPost.DateModified = DateTime.Now;

            await this.blogContext.AddAsync<BlogPost>(blogPost);
            await this.blogContext.SaveChangesAsync();
        }

        public Task<BlogServiceModel> Edit(BlogServiceModel blogServiceModel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exists(Guid? id)
        {
            if(!id.HasValue)
            {
                return false;
            }

            var result = await this.blogContext.Blogs.AnyAsync(x => x.Id == id);

            return result;
        }

        public IQueryable<BlogPost> GetAll()
        {
            var result = this.blogContext.Blogs.AsQueryable();

            return result;
        }

        public async Task<BlogPost> GetById(Guid? id)
        {
            if(!id.HasValue)
            {
                return null;
            }

            var result = await this.blogContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
