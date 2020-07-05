namespace Blog.Controllers.FrontEnd
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Helpers;
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
        public async Task<IActionResult> AddComment([FromBody]CreateCommentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new {success = false, message = "Invalid content!"});
            }

            if (!User.Identity.IsAuthenticated)
            {
                return Json(new {success = false, message = "Have to be logged in!"});
            }

            var serviceModel = _mapper.Map<CommentServiceModel>(viewModel);

            serviceModel.UserId = this.User.GetLoggedInUserId<string>();
            serviceModel.Username = this.User.GetLoggedInUserName();
            serviceModel.Email = this.User.GetLoggedInUserName();

            await _commentService.AddComment(serviceModel);

            return View();
        }
    }
}