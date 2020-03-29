namespace Blog.Controllers.Controllers.Public
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Contracts;

    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddComment()
        {
            return View();
        }
    }
}