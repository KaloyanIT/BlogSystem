namespace Blog.Services.BlogPostTags
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models;
    using Data.Models.Context;
    using Microsoft.Extensions.Logging;

    public class BlogPostTagsService : BaseService, IBlogPostTagsService
    {
        private readonly BlogContext _blogContext;

        public BlogPostTagsService(
            BlogContext blogContext,
            IMapper mapper,
            ILogger<BaseService> logger) : base(mapper, logger)
        {
            _blogContext = blogContext;
        }


        public async Task CreateTags(Guid blogId, ICollection<Guid> tagIds)
        {
            if (tagIds.Count == 0)
            {
                return;
            }


            foreach (var tagId in tagIds)
            {
                var blogPostTag = new BlogPostTag(blogId, tagId);

                await _blogContext.AddAsync(blogPostTag);
            }

            await _blogContext.SaveChangesAsync();
        }
    }
}