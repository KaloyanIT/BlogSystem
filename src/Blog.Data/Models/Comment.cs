using System;

namespace Blog.Data.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid BlogId { get; set; }

        public virtual BlogPost Blog { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
