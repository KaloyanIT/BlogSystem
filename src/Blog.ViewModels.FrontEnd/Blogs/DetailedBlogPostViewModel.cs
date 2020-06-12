namespace Blog.ViewModels.FrontEnd.Blogs
{
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedBlogPostViewModel : IHaveMapFrom<BlogPost>
    {
        public string Title { get; set; } = null!;

        public string Summary { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
