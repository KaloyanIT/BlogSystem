using System;
using System.Collections.Generic;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class Keyword : BaseDbObject
    {
        public string Name { get; set; }

        public virtual  ICollection<BlogPostKeyword> BlogKeywords { get; set; }

        public Keyword() { }

        public Keyword(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Keyword name can not be null.");
            }

            this.Name = name;
        }
    }
}
