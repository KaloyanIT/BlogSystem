using System;
using System.Collections.Generic;
using System.Text;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class BlogPostTag : BaseDbObject
    {
        public Guid BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
