using System;
using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;

namespace Blog.Controllers.ViewModels.Blogs
{
    public class BlogDisplayViewModel : IHaveMapFrom<BlogPost>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public string CommentsCount { get; set; }

        public DateTime DateModified { get; set; }

        public string Summary { get; set; }
    }
}