namespace Blog.ViewModels.BackEnd.Blogs
{
    using System.ComponentModel.DataAnnotations;
    using Blog.Services.Blog.Models;
    using Blog.ViewModels.BackEnd.Meta.OpenGraphs;
    using Infrastructure.AutoMapper;

    public class CreateBlogViewModel : IHaveReverseMap<CreateBlogServiceModel>
    {
        public CreateBlogViewModel()
        {
            this.OpenGraphViewModel = new OpenGraphViewModel();
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public string Summary { get; set; } = null!;

        public OpenGraphViewModel OpenGraphViewModel {get; set;}

        public bool ShowOnHomepage { get; set; }
    }
}
