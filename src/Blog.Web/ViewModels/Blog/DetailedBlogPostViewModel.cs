using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;

namespace Blog.Web.ViewModels.Blog
{
    public class DetailedBlogPostViewModel : IHaveMapFrom<BlogPost>
    {
        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }
    }
}
