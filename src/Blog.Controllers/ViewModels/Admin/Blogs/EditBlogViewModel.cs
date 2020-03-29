namespace Blog.Controllers.ViewModels.Admin.Blogs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.AutoMapper;
    using Services.Models;

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
