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
    }
}
