
namespace Blog.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Base;

    public class Tag : BaseDbObject
    {
        public string Name { get; private set; }

        public ICollection<BlogPostTag> BlogPostTag { get; private set; }

        public Tag() 
        {
            Name = string.Empty;
            BlogPostTag = new List<BlogPostTag>();
        }

        public Tag(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentNullException("Tag name can not be null or whitespace or with length less than 3 characters.");
            }

            Name = name;
            BlogPostTag = new List<BlogPostTag>();
        }

        public void EditName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentNullException("Tag name can not be null or whitespace or with length less than 3 characters.");
            }

            Name = name;
        }
    }
}
