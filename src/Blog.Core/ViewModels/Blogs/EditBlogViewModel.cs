using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Core.ViewModels.Blogs
{
    public class EditBlogViewModel
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
