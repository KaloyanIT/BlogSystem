using Blog.Data.Models;
using Blog.DataAccess.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories.Comments
{
    public class CommentRepository : SqlServerEntityFrameworkCrudRepository<Comment, BlogContext>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Comment> EntityDbSet => this.Context.Comments;
    }
}
