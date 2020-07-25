namespace Blog.ViewModels.BackEnd.Comments
{
    using System;
    using Data.Models.Comments;
    using Infrastructure.AutoMapper;
    using Services.Comment.Models;

    public class EditCommentViewModel : IHaveMapTo<EditCommentServiceModel>, IHaveMapFrom<Comment>
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
    }
}
