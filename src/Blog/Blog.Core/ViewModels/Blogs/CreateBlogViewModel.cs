using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.ViewModels.Blogs
{
    public class CreateBlogViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
