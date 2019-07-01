using Blog.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Index()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult AddComment()
        {
            return this.View();
        }
    }
}