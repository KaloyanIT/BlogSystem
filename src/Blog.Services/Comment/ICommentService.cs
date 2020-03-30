namespace Blog.Services.Comment
{
    using System.Threading.Tasks;
    using Base;

    public interface ICommentService : IService
    {
        Task AddComment();

        Task<bool> DeleteComment();

        Task Edit();
    }
}
