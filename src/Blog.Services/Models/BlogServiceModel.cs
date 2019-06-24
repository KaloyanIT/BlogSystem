using System;

namespace Blog.Services.Models
{
    public class BlogServiceModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool ShowOnHomePage { get; set; }

        public Guid UserId { get; set; }
    }
}
