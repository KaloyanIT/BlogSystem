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
            var comment = new Comment(commentServiceModel.AttachedItemId,
                commentServiceModel.CommentItemType,
                commentServiceModel.Username, 
                commentServiceModel.Email, 
                commentServiceModel.Content,
                commentServiceModel.UserId);

            try
            {
                await _commentRepository.Save(comment);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public Task<bool> DeleteComment()
        {
            throw new NotImplementedException();
        }

        public async Task Edit(string content, Guid id)
        {
            var comment = await _commentRepository.GetById(id);

            if(comment == null)
            {
                throw new Exception("Comment content can not be null!");
            }

            comment.Edit(content);

            await _commentRepository.Save(comment);
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

        public async Task VoteUp(Guid commentId)
        {
            var comment = await this.GetById(commentId);

            if (comment != null)
            {
                comment.VoteUp();

                await _commentRepository.Save(comment);
            }
        }

        public async Task VoteDown(Guid commentId)
        {
            var comment = await this.GetById(commentId);

            if (comment != null)
            {
                comment.VoteDown();

                await _commentRepository.Save(comment);
            }
        }

        public async Task<Comment?> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            var item = await _commentRepository.GetById(id);

            return item;
        }
    }
}
