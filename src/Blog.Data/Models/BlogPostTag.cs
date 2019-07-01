using Blog.Data.Base;
using System;

namespace Blog.Data.Models
{
    public class BlogPostTag : BaseDbObject
    {
        public Guid BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public BlogPostTag() { }

        public BlogPostTag(Guid blogPostId, Guid tagId)
        {
            if (blogPostId == Guid.Empty)
            {
                throw new ArgumentNullException("BlogPostTag blogPostId can not be empty guid.");
            }

            if (tagId == Guid.Empty)
            {
                throw new ArgumentNullException("BlogPostTag tagId can not be empty guid.");
            }

            this.BlogPostId = blogPostId;
            this.TagId = tagId;
        }

        public BlogPostTag(BlogPost blogPost, Tag tag)
        {
            if(blogPost == null)
            {
                throw new ArgumentNullException("Blog post can not be null.");
            }

            if(tag == null)
            {
                throw new ArgumentNullException("Tag can not be null.");
            }

            this.BlogPost = blogPost;
            this.Tag = tag;
        }
    }
}
