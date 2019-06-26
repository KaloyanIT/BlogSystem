using System;
using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;

namespace Blog.Services.Models
{
    public class BlogServiceModel : IHaveMapFrom<BlogPost>, IHaveMapTo<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool ShowOnHomePage { get; set; }

        public Guid UserId { get; set; }
    }
}
