using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;

namespace Blog.Core.ViewModels.Blogs
{
    public class DetailedBlogViewModel : BlogViewModel, IHaveMapFrom<BlogPost>
    {
        public string Username { get; set; }
    }
}
