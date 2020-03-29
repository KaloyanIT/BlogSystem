namespace Blog.Controllers.ViewModels.Public.Blogs
{
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedBlogPostViewModel : IHaveMapFrom<BlogPost>
    {
        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }
    }
}
