using System;
using System.Collections.Generic;

namespace Blog.Data.Models
{
    public class BlogPost
    {
        private ICollection<Comment> comments;
        public BlogPost()
        {
            this.comments = new HashSet<Comment>();
        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<Comment> Comments { get => this.comments; set => this.comments = value; }
    }
}
