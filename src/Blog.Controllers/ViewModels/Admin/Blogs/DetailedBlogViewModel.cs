namespace Blog.Controllers.ViewModels.Admin.Blogs
{
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedBlogViewModel : BlogViewModel, IHaveMapFrom<BlogPost>
    {
        public string Username { get; set; }
    }
}
