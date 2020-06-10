namespace Blog.ViewModels.BackEnd.Blogs
{
    using System.ComponentModel.DataAnnotations;
    using Blog.Services.Blog.Models;
    using Infrastructure.AutoMapper;

    public class CreateBlogViewModel : IHaveReverseMap<CreateBlogServiceModel>
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public string Summary { get; set; } = null!;

        public bool ShowOnHomepage { get; set; }
    }
}
