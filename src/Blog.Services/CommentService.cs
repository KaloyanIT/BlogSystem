using Blog.Data.Repositories.Comments;
using Blog.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
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
