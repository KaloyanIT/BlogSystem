namespace Blog.Data.Repositories.Comments
{
    using System;
    using System.Linq;
    using Models;
    using DataAccess;
    using Base;

    public interface ICommentRepository : IRepository<Comment>, ITransientRepository
    {
        IQueryable<Comment> GetCommentsForItem(Guid itemId, string attachedItem);

        IQueryable<Comment> GetCommentsForUser(string userId);

        IQueryable<Comment> GetCommentsFromAnonymousUser(string attachedItem);

        IQueryable<Comment> GetCommentsForItem(Guid id);
    }
}
