namespace Blog.Services.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task AddComment();

        Task<bool> DeleteComment();

        Task Edit();
    }
}
