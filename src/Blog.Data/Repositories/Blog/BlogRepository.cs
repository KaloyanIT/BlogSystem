using Blog.Data.Models;
using Blog.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Blog
{
    public class BlogRepository : SqlServerEntityFrameworkCrudRepository<BlogPost, BlogContext>, IBlogRepository
    {
        public BlogRepository(BlogContext context) : base(context)
        {

        }

        protected override DbSet<BlogPost> EntityDbSet => this.Context.Blogs;

        public async Task<BlogPost> GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Blog title is null.");
            }

            var result = await this.GetAll().FirstOrDefaultAsync(x => x.Title == title);

            return result;
        }
    }
}
