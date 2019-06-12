using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.ViewModels.Blogs
{
    public class BlogDisplayViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public string CommentsCount { get; set; }

        public DateTime DateModified { get; set; }

        public string Summary { get; set; }
    }
}
