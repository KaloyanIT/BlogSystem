namespace Blog.ViewModels.FrontEnd.Blogs
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedBlogPostViewModel : IHaveMapFrom<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
