namespace Blog.Controllers.ViewModels.Admin.Blogs
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class BlogDisplayViewModel : IHaveMapFrom<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Creator { get; set; } = null!;

        public string? CommentsCount { get; set; }

        public DateTime DateModified { get; set; }

        public string Summary { get; set; } = null!;
    }
}