using Blog.Data.Models;
using Blog.Infrastructure.AutoMapper;

namespace Blog.Controllers.ViewModels.Blogs
{
    public class DetailedBlogViewModel : BlogViewModel, IHaveMapFrom<BlogPost>
    {
        public string Username { get; set; }
    }
}
