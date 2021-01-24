namespace Blog.Services.Tags
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models;
    using Data.Repositories.BlogPostTags;
    using Data.Repositories.Tags;
    using Microsoft.Extensions.Logging;
    using Tags.Models;

    public class TagService : BaseService, ITagService
    {
        private readonly ITagRepository _tagSqlRepository;
        private readonly IBlogPostTagRepository _blogPostTagRepository;

        public TagService(ITagRepository tagSqlRepository,
            IBlogPostTagRepository blogPostTagRepository,
            IMapper mapper, 
            ILogger<TagService> logger) : base(mapper, logger)
        {
            _tagSqlRepository = tagSqlRepository ??
                throw new ArgumentNullException(nameof(tagSqlRepository), "TagSqlRepository is null.");
            _blogPostTagRepository = blogPostTagRepository ??
                throw new ArgumentNullException(nameof(blogPostTagRepository), "BlogPostTagRepository is null.");
        }

        public async Task Create(CreateTagServiceModel serviceModel)
        {        
            if(serviceModel == null)
            {
                throw new ArgumentNullException(nameof(serviceModel));
            }

            var tag = new Tag(serviceModel.Name);

            await _tagSqlRepository.Save(tag);
        }

        public async Task DeleteById(Guid? id)
        {
            var tag = await this.GetById(id);

            if(tag == null)
            {
                return;
            }

            await _tagSqlRepository.Delete(tag);
        }

        public async Task Edit(EditTagServiceModel serviceModel)
        {
            var tag = await this.GetById(serviceModel.Id);

            if(tag == null)
            {
                return;
            }

            tag.EditName(serviceModel.Name);

            await _tagSqlRepository.Save(tag);
        }

        public IQueryable<Tag> GetAll()
        {
            var tags = _tagSqlRepository.GetAll();

            return tags;
        }

        public Task<Tag> GetById(Guid? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException(nameof(id), "TagService GetById id has no value");
            }

            var result = _tagSqlRepository.GetById(id.Value);

            return result;
        }

        public async Task Save(TagServiceModel value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "TagServiceModel is null.");
            }
            Tag tag;
            if (value.Id == Guid.Empty)
            {
                tag = new Tag(value.Name);
            }
            else
            {
                tag = await _tagSqlRepository.GetById(value.Id);
            }

            tag.EditName(value.Name);

            await _tagSqlRepository.Save(tag);
        }
    }
}
