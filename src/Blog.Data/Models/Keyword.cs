
namespace Blog.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Base;

    public class Keyword : BaseDbObject
    {
        public string Name { get; private set; }

        public virtual ICollection<BlogPostKeyword> BlogKeywords { get; private set; }

        public Keyword() { }

        public Keyword(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Keyword name can not be null.");
            }

            Name = name;
        }
    }
}
