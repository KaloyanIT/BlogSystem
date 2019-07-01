using Blog.Data.Models;
using Blog.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Repositories.BlogPostKeywords
{
    public class BlogPostKeywordRepository : SqlServerEntityFrameworkCrudRepository<BlogPostKeyword, BlogContext>, IBlogPostKeywordRepository
    {
        public BlogPostKeywordRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<BlogPostKeyword> EntityDbSet => this.Context.BlogPostKeywords;
    }
}
