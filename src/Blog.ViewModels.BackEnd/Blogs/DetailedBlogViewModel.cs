namespace Blog.ViewModels.BackEnd.Blogs
{
    using Blog.ViewModels.BackEnd.Meta.OpenGraphs;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedBlogViewModel : BlogViewModel, IHaveMapFrom<BlogPost>
    {
        public string Username { get; set; } = null!;

        public OpenGraphViewModel OpenGraph {get; set; } = null!;
    }
}
