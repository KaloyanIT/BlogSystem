using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace Blog.Services
{
    using Microsoft.EntityFrameworkCore;

    using Data.Models;
    using Data.Repositories.Blog;
    using Contracts;
    using Models;

    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }


        public async Task Create(CreateBlogServiceModel serviceModel)
        {
            var blogPost = new BlogPost(serviceModel.Title, serviceModel.Content, serviceModel.Summary, serviceModel.UserId, serviceModel.ShowOnHomePage);

            await _blogRepository.Save(blogPost);
        }

        public async Task<BlogServiceModel> Edit(BlogServiceModel blogServiceModel)
        {
            var blog = _mapper.Map<BlogPost>(blogServiceModel);

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

        public async Task<BlogPost> GetById(Guid? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            var result = await _blogRepository.GetById(id.Value);

            return result;
        }
    }
}
