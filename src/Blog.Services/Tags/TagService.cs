namespace Blog.Services.Tags
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Data.Models;
    using Data.Repositories.BlogPostTags;
    using Data.Repositories.Tags;
    using Tags.Models;

    public class TagService : ITagService
    {
        private readonly ITagRepository _tagSqlRepository;
        private readonly IBlogPostTagRepository _blogPostTagRepository;

        public TagService(ITagRepository tagSqlRepository, IBlogPostTagRepository blogPostTagRepository)
        {
            _tagSqlRepository = tagSqlRepository ?? throw new ArgumentNullException("tagSqlRepositoryInstance", "TagSqlRepository is null.");
            _blogPostTagRepository = blogPostTagRepository ?? throw new ArgumentNullException("blogPostTagRepositoryInstance", "BlogPostTagRepository is null.");
        }

        public Task DeleteById(Guid? id)
        {
            throw new NotImplementedException();
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
                throw new ArgumentNullException("id", "TagService GetById id has no value");
            }

            var result = _tagSqlRepository.GetById(id.Value);

            return result;
        }

        public async Task Save(TagServiceModel value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("tagServiceModel", "TagServiceModel is null.");
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
