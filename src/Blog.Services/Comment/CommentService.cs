namespace Blog.Services.Comment
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models.Comments;
    using Data.Repositories.Comments;
    using Microsoft.Extensions.Logging;
    using Models;

    public class CommentService : BaseService, ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository,
            IMapper mapper,
            ILogger<CommentService> logger) : base(mapper, logger)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddComment(CommentServiceModel commentServiceModel)
        {
            var comment = Mapper.Map<Comment>(commentServiceModel);

            await _commentRepository.Save(comment);
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
