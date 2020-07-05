using Blog.Data.Models.Comments;

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
        public IQueryable<Comment> GetCommentsForItem(Guid itemId, CommentItemType itemType)
        {
            var result = EntityDbSet
                .Where(x => x.AttachedItemId == itemId 
                            && x.CommentItemType == itemType);

            return result;
        }

        public IQueryable<Comment> GetCommentsForUser(string userId)
        {
            var result = EntityDbSet
                .Where(x => x.UserId == userId);

            return result;
        }

        public IQueryable<Comment> GetCommentsFromAnonymousUser()
        {
            var result = EntityDbSet
                .Where(x => x.CommentItemType == CommentItemType.Anonymous);

            return result;
        }

        public IQueryable<Comment> GetCommentsForItem(Guid id)
        {
            var result = EntityDbSet
                .Where(x => x.AttachedItemId == id);

            return result;
        }
    }
}
