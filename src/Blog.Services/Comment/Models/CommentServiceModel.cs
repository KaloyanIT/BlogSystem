namespace Blog.Services.Comment.Models
{
    using System;

    public class CommentServiceModel
    {
        public Guid AttachedItemId { get; set; }
        
        public string AttachedItemType { get; set; } = null!;

        public string? UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
