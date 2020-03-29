namespace Blog.Services.Models
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class BlogServiceModel : IHaveReverseMap<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public bool ShowOnHomePage { get; set; }

        public Guid UserId { get; set; }
    }
}
