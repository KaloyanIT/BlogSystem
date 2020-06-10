namespace Blog.ViewModels.BackEnd.Blogs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.AutoMapper;
    using Services.Blog.Models;

    public class EditBlogViewModel : IHaveReverseMap<BlogServiceModel>, IHaveMapFrom<BlogPost>
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public string Summary { get; set; } = null!;

        public bool ShowOnHomepage { get; set; }
    }
}
