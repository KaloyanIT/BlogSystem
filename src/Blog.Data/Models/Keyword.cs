using System;
using System.Collections.Generic;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class Keyword : BaseDbObject
    {
        public string Name { get; set; }

        public ICollection<BlogPostKeyword> BlogKeywords { get; set; }
    }
}
