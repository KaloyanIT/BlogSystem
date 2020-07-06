using Blog.Data.Models.Comments;

namespace Blog.ViewModels.BackEnd.Comments
{
    using System;
    using Base;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class CommentViewModel : BaseGridViewModel, IHaveMapFrom<Comment>
    {
        public Guid AttachedItemId { get; set; }

        public string AttachedItemType { get; set; }

        public string? UserId { get; set; }

        public string Username { get; set; }
        
        public string Email { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }
    }
}
