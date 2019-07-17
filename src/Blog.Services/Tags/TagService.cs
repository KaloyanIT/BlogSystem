using Blog.Data.Models;
using Blog.Data.Repositories.BlogPostTags;
using Blog.Data.Repositories.Tags;
using Blog.Services.Tags.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagSqlRepository tagSqlRepository;
        private readonly IBlogPostTagRepository blogPostTagRepository;

        public TagService(ITagSqlRepository tagSqlRepository, IBlogPostTagRepository blogPostTagRepository)
        {
            this.tagSqlRepository = tagSqlRepository ?? throw new ArgumentNullException("tagSqlRepositoryInstance", "TagSqlRepository is null.");
            this.blogPostTagRepository = blogPostTagRepository ?? throw new ArgumentNullException("blogPostTagRepositoryInstance", "BlogPostTagRepository is null.");
        }

        public Task DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tag> GetAll()
        {
            var tags = this.tagSqlRepository.GetAll();

            return tags;
        }

        public Task<Tag> GetById(Guid? id)
        {
            if(!id.HasValue)
            {
                throw new ArgumentNullException("id", "TagService GetById id has no value");
            }

            var result = this.tagSqlRepository.GetById(id.Value);

            return result;
        }

        public async Task Save(TagServiceModel value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("tagServiceModel", "TagServiceModel is null.");
            }
            Tag tag;
            if(value.Id == Guid.Empty)
            {
                tag = new Tag(value.Name);
            }
            else
            {
                tag = await this.tagSqlRepository.GetById(value.Id);
            }

            tag.EditName(value.Name);

            await this.tagSqlRepository.Save(tag);
        }
    }
}
