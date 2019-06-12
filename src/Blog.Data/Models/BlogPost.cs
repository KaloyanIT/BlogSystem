using Blog.Data.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Blog.Data.Models
{
    public class BlogPost : BaseDbObject
    {      
        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public bool ShowOnHomePage { get; set; }

        public Guid UserId { get; set; }

        public IdentityUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public BlogPost() : base()
        {
        }

        public BlogPost(string title, string content, string summary, Guid userId, bool showOnHomePage = true) : base()
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("BlogPost title");
            }

            if(string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("BlogPost content");
            }

            if(string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentNullException("BlogPost Summary");
            }

            if(userId == null || userId == Guid.Empty)
            {
                throw new ArgumentNullException("BlogPost UserId");
            }

            this.Title = title;
            this.Content = content;
            this.Summary = summary;
            this.UserId = userId;
            this.ShowOnHomePage = showOnHomePage;
        }
    }
}
