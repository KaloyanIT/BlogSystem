namespace Blog.Services.BlogPostTags
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Base;

    public interface IBlogPostTagsService : IService
    {
        Task CreateTags(Guid blogId, ICollection<Guid> tagIds);
    }
}