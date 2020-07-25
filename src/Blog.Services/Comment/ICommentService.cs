namespace Blog.Services.Comment
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Data.Models.Comments;
    using Models;

    public interface ICommentService : IService
    {
        Task AddComment(CommentServiceModel serviceModel);

        Task<bool> DeleteComment();

        Task Edit(EditCommentServiceModel serviceModel);

        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetAllForItem(Guid itemId);

        IQueryable<Comment> GetAll(Guid itemId, CommentItemType itemType);

        Task VoteUp(Guid commentId);

        Task VoteDown(Guid commentId);

        Task<Comment?> GetById(Guid id);
    }
}
