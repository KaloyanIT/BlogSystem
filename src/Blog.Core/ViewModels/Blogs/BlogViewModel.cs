using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;

namespace Blog.Core.ViewModels.Blogs
{
    public class BlogViewModel : IHaveMapFrom<BlogPost>
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
