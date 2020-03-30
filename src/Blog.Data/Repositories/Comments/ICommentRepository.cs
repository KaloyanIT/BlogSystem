namespace Blog.Data.Repositories.Comments
{
    using Models;
    using DataAccess;
    using Base;

    public interface ICommentRepository : IRepository<Comment>, ITransientRepository
    {
    }
}
