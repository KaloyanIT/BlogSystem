namespace Blog.Controllers.FrontEnd
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Comment;
    using ViewModels.FrontEnd.Comments;

    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody]CreateCommentViewModel viewModel)
        {
            return View();
        }
    }
}