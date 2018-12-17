using System;

namespace Blog.Data
{
    public class BlogPost
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
