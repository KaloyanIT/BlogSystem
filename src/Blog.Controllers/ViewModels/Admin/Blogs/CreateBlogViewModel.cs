namespace Blog.Controllers.ViewModels.Admin.Blogs
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.AutoMapper;
    using Services.Blog.Models;

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
