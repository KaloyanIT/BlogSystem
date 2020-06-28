namespace Blog.Data.Repositories.Comments
{
    using System;
    using System.Linq;
    using Data.Models;
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;
    using Models.Context;

    public class CommentRepository : SqlServerEntityFrameworkCrudRepository<Comment, BlogContext>, ICommentRepository
    {
        public CommentRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Comment> EntityDbSet => Context.Comments;
        public IQueryable<Comment> GetCommentsForItem(Guid itemId, string attachedItem)
        {
            var result = EntityDbSet
                .Where(x => x.AttachedItemId == itemId && x.AttachedItemType == attachedItem);

            return result;
        }

        public IQueryable<Comment> GetCommentsForUser(string userId)
        {
            var result = EntityDbSet
                .Where(x => x.UserId == userId);

            return result;
        }

        public IQueryable<Comment> GetCommentsFromAnonymousUser(string attachedItem)
        {
            var result = EntityDbSet
                .Where(x => x.UserId == null && x.AttachedItemType == attachedItem);

            return result;
        }
    }
}
