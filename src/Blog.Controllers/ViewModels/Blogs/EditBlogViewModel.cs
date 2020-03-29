using System;
using System.ComponentModel.DataAnnotations;
using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;
using Blog.Services.Models;

namespace Blog.Controllers.ViewModels.Blogs
{
    public class EditBlogViewModel : IHaveReverseMap<BlogServiceModel>, IHaveMapFrom<BlogPost>
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Summary { get; set; }

        public bool ShowOnHomepage { get; set; }
    }
}
