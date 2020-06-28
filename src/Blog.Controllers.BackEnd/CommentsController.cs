namespace Blog.Controllers.BackEnd
{
    using AutoMapper;
    using Base;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Comment;
    using ViewModels.BackEnd.Comments;

    [Area("Admin")]
    public class CommentsController : BackEndController
    {
        private readonly ICommentService _commentService;

        public CommentsController(
            ICommentService commentService,
            ILogger<BackEndController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _commentService = commentService;
        }

        public IActionResult Index(int page = 1)
        {
            var viewModel = _commentService.GetAll()
                .To<CommentViewModel>()
                .GetPaged(page, MaxPageSize);

            return View(viewModel);
        }
    }
}
