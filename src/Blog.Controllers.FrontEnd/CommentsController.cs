namespace Blog.Controllers.FrontEnd
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Services.Comment;
    using Services.Comment.Models;
    using ViewModels.FrontEnd.Comments;

    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService,
            IMapper mapper
        )
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddComment([FromBody]CreateCommentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new {success = false, message = "Invalid content!"});
            }

            var serviceModel = _mapper.Map<CommentServiceModel>(viewModel);

            var user = this.User.Identity.Name;

            return View();
        }
    }
}