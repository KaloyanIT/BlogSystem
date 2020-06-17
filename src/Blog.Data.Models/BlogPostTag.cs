
namespace Blog.Data.Models
{
    using System;

    using Base;

    public class BlogPostTag : BaseDbObject
    {
        public Guid BlogPostId { get; private set; }

        public BlogPost? BlogPost { get; private set; }

        public Guid TagId { get; private set; }

        public Tag? Tag { get; private set; }

        public BlogPostTag() { }

        public BlogPostTag(Guid blogPostId, Guid tagId)
        {
            if (blogPostId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(blogPostId), "BlogPostTag blogPostId can not be empty guid.");
            }

            if (tagId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(tagId), "BlogPostTag tagId can not be empty guid.");
            }

            BlogPostId = blogPostId;
            TagId = tagId;
        }

        public BlogPostTag(BlogPost blogPost, Tag tag)
        {
            if (blogPost == null)
            {
                throw new ArgumentNullException(nameof(blogPost), "Blog post can not be null.");
            }

            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag), "Tag can not be null.");
            }

            BlogPost = blogPost;
            Tag = tag;
        }
    }
}
