namespace Blog.Services.Comment
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models.Comments;
    using Data.Repositories.Comments;

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

        public IQueryable<Comment> GetAll()
        {
            var result = _commentRepository.GetAll();

            return result;
        }

        public IQueryable<Comment> GetAllForItem(Guid itemId)
        {
            var result = _commentRepository.GetCommentsForItem(itemId);

            return result;
        }

        public IQueryable<Comment> GetAll(Guid itemId, CommentItemType itemType)
        {
            var result = _commentRepository.GetCommentsForItem(itemId, itemType);

            return result;
        }
    }
}
