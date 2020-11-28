namespace Blog.Controllers.FrontEnd
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using AutoMapper;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid content!" });
            }

            if (!User.Identity!.IsAuthenticated)
            {
                return Json(new { success = false, message = "Have to be logged in!" });
            }

            var serviceModel = _mapper.Map<CommentServiceModel>(viewModel);

            serviceModel.UserId = User.GetLoggedInUserId<string>();
            serviceModel.Username = User.GetLoggedInUserName();
            serviceModel.Email = User.GetLoggedInUserName();

            await _commentService.AddComment(serviceModel);

            return Json(new { success = true, message = "Comment is successfully created." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoteUp([FromBody] GuidJsonModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new {success = false, message = "Vote is not successful."});
            }

            await _commentService.VoteUp(viewModel.Id);

            return this.Json(new {success = true, message = "You successfully voted for this comment."});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoteDown([FromBody] GuidJsonModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new {success = false, message = "Vote is not successful."});
            }

            await _commentService.VoteDown(viewModel.Id);

            return this.Json(new {success = true, message = "You successfully voted for this comment."});
        }

    }

    public class GuidJsonModel
    {
        [Required]
        public Guid Id { get; set; }
    }

    public class NotLikeAttribute : ValidationAttribute
    {
        private readonly string _comparisonValue;
        public NotLikeAttribute(string comparisonValue)
        {
            _comparisonValue = comparisonValue;
        }

        protected override ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {       
            if (object.Equals(value, _comparisonValue))
            {
                // here i am verifying whether the 2 values are equal
                // here you could do any custom validation you like
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success!;
        }
    }
}