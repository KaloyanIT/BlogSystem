using System;
using System.Collections.Generic;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class Tag : BaseDbObject
    {
        public string Name { get; private set; }

        public virtual ICollection<BlogPostTag> BlogPostTag { get; private set; }

        public Tag() { }

        public Tag(string name)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentNullException("Tag name can not be null or whitespace or with length less than 3 characters.");
            }

            this.Name = name;
        }

        public void EditName(string name)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentNullException("Tag name can not be null or whitespace or with length less than 3 characters.");
            }

            this.Name = name;
        }
    }
}
