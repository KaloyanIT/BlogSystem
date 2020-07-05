namespace Blog.Services.Comment.Models
{
    using System;
    using Data.Models.Comments;
    using Infrastructure.AutoMapper;

    public class CommentServiceModel : IHaveMapTo<Comment>
    {
        public Guid AttachedItemId { get; set; }
        
        public CommentItemType CommentItemType { get; set; }

        public string? UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
