using Blog.Data.Base;
using System;
using System.Collections.Generic;

namespace Blog.Data.Models
{
    public class BlogPost : BaseDbObject
    {      
        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public BlogPost()
        {
        }

        public BlogPost(string title, string content)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("BlogPost title");
            }

            if(string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("BlogPost content");
            }

            this.Title = title;
            this.Content = content;
        }
    }
}
