namespace Blog.Services.Comment
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Data.Models;

    public interface ICommentService : IService
    {
        Task AddComment();

        Task<bool> DeleteComment();

        Task Edit();

        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetAllForItem(Guid itemId);
    }
}
