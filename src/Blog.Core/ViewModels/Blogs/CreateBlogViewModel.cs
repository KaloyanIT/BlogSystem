﻿using System.ComponentModel.DataAnnotations;

namespace Blog.Core.ViewModels.Blogs
{
    public class CreateBlogViewModel
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
