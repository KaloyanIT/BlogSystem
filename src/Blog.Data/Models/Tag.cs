using System;
using System.Collections.Generic;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class Tag : BaseDbObject
    {
        public string Name { get; set; }

        public ICollection<BlogPostTag> BlogPostTag { get; set; }
    }
}
