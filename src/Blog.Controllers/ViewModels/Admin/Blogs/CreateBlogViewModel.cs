namespace Blog.Controllers.ViewModels.Admin.Blogs
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.AutoMapper;
    using Services.Blog.Models;

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
