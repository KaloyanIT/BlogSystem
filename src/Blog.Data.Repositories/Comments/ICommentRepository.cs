using Blog.Data.Models.Comments;

namespace Blog.Data.Repositories.Comments
{
    using System;
    using System.Linq;
    using Models;
    using DataAccess;
    using Base;

    public interface ICommentRepository : IRepository<Comment>, ITransientRepository
    {
        IQueryable<Comment> GetCommentsForItem(Guid itemId, CommentItemType itemType);

        IQueryable<Comment> GetCommentsForUser(string userId);

        IQueryable<Comment> GetCommentsFromAnonymousUser();

        IQueryable<Comment> GetCommentsForItem(Guid id);
    }
}
