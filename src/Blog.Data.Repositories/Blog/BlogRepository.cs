namespace Blog.Data.Repositories.Blog
{
    using System;
    using System.Threading.Tasks;

    using Data.Models;
    using DataAccess.SqlServer;
    using Models.Context;
    using Microsoft.EntityFrameworkCore;

    public class BlogRepository : SqlServerEntityFrameworkCrudRepository<BlogPost, BlogContext>, IBlogRepository
    {
        public BlogRepository(BlogContext context) : base(context)
        {

        }

        protected override DbSet<BlogPost> EntityDbSet => Context.Blogs;

        public async Task<BlogPost> GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Blog title is null.");
            }

            var result = await GetAll().FirstOrDefaultAsync(x => x.Title == title);

            return result;
        }
    }
}
