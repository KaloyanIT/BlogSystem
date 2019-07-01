using System;
using System.Collections.Generic;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class Tag : BaseDbObject
    {
        public string Name { get; set; }

        public virtual ICollection<BlogPostTag> BlogPostTag { get; set; }

        public Tag() { }

        public Tag(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Tag name can not be null or whitespace.");
            }

            this.Name = name;
        }
    }
}
