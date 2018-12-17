using Blog.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.Models
{
    public class BlogServiceModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
