namespace Blog.ViewModels.FrontEnd.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Comments;
    using Infrastructure.AutoMapper;
    using Services.Comment.Models;

    public class CreateCommentViewModel : IHaveMapTo<CommentServiceModel>
    {
        public string AttachedItemId { get; set; }

        public string CommentItemType { get; set; }

        [Required]
        public string Content { get; set; } = null!;
    }
}
