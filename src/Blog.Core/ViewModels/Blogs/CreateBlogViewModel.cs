using System.ComponentModel.DataAnnotations;
using Blog.Infrastructure.AutoMapper;
using Blog.Services.Models;

namespace Blog.Core.ViewModels.Blogs
{
    public class CreateBlogViewModel : IHaveReverseMap<CreateBlogServiceModel>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Summary { get; set; }

        public bool ShowOnHomepage { get; set; }
    }
}
