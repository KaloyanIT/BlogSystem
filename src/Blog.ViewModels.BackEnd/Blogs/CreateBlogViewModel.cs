namespace Blog.ViewModels.BackEnd.Blogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Blog.Services.Blog.Models;
    using Blog.ViewModels.BackEnd.Meta.OpenGraphs;
    using Blog.ViewModels.BackEnd.Tags;
    using Infrastructure.AutoMapper;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreateBlogViewModel : IHaveReverseMap<CreateBlogServiceModel>
    {
        public CreateBlogViewModel()
        {
            OpenGraphViewModel = new OpenGraphViewModel();
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        public string Summary { get; set; } = null!;

        [Required]
        public string Slug {get; set; } = null!;

        public OpenGraphViewModel OpenGraphViewModel { get; set; }

        public ICollection<Guid> TagIds { get; set; } = null!;

        public ICollection<SelectListItem> TagsSelectListItems {get; set;} = null!;

        public bool ShowOnHomepage { get; set; }
    }
}
