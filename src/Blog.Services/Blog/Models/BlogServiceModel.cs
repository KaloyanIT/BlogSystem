namespace Blog.Services.Blog.Models
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class BlogServiceModel : IHaveReverseMap<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string Slug {get; set; } = null!;

        public bool ShowOnHomePage { get; set; }

        public Guid UserId { get; set; }
    }
}
