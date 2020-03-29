using System;
using Blog.Data.Repositories.Comments;
using Blog.Services.Contracts;
namespace Blog.Services.Comment
{
    using System.Threading.Tasks;

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task AddComment()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteComment()
        {
            throw new NotImplementedException();
        }

        public Task Edit()
        {
            throw new NotImplementedException();
        }
    }
}
