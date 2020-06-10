namespace Blog.ViewModels.BackEnd.Blogs
{
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedBlogViewModel : BlogViewModel, IHaveMapFrom<BlogPost>
    {
        public string Username { get; set; } = null!;
    }
}
