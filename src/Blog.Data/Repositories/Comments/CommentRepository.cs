namespace Blog.Data.Repositories.Comments
{
    using Data.Models;
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;

    public class CommentRepository : SqlServerEntityFrameworkCrudRepository<Comment, BlogContext>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Comment> EntityDbSet => this.Context.Comments;
    }
}
