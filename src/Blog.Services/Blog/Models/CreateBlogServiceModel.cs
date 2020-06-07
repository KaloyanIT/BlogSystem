using System;
using Blog.Data.Models;
namespace Blog.Services.Blog.Models
{
    using Infrastructure.AutoMapper;

    public class CreateBlogServiceModel : IHaveMapTo<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public bool ShowOnHomePage { get; set; }

        public string UserId { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
