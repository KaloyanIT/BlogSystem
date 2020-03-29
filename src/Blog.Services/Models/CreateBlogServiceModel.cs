using System;
using Blog.Data.Models;
namespace Blog.Services.Models
{
    using Infrastructure.AutoMapper;

    public class CreateBlogServiceModel : IHaveMapTo<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public bool ShowOnHomePage { get; set; }

        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
