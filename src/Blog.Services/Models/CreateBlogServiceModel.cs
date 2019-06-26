using System;
using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;

namespace Blog.Services.Models
{
    public class CreateBlogServiceModel : IHaveMapTo<BlogPost>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public bool ShowOnHomePage { get; set; }

        public Guid UserId { get; set; }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
