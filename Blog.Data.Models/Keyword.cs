
namespace Blog.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Base;

    public class Keyword : BaseDbObject
    {
        public string Name { get; private set; }

        public ICollection<BlogPostKeyword> BlogKeywords { get; private set; }

        public Keyword() 
        {
            Name = string.Empty;
            BlogKeywords = new List<BlogPostKeyword>();
        }

        public Keyword(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Keyword name can not be null.");
            }

            Name = name;
            BlogKeywords = new List<BlogPostKeyword>();
        }
    }
}
