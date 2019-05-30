using AutoMapper;
using Blog.Data;
using Blog.Data.Models;
using Blog.Services.Contracts;
using Blog.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogContext blogContext;
        private readonly IMapper mapper;

        public BlogService(IBlogContext blogContext, IMapper mapper)
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

        public Task<ICollection<BlogServiceModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BlogServiceModel> GetById()
        {
            throw new NotImplementedException();
        }
    }
}
