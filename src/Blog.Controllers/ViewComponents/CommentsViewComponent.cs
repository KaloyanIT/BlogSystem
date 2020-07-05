namespace Blog.Controllers.ViewComponents
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models.Comments;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Comment;
    using ViewModels.FrontEnd.Comments;

    public class CommentsViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentsViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id, CommentItemType commentItemType, string templateName = "Default")
        {
            var comments = _commentService.GetAll(id, commentItemType)
                .To<CommentDetailedViewModel>();

            return (IViewComponentResult)View(templateName, comments.ToList());
        }
    }
}
