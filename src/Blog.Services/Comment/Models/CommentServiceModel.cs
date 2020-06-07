namespace Blog.Services.Comment.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class CommentServiceModel
    {
        public Guid Id { get; set; }

        public Guid AttachedItemId { get; set; }

        public string AttachedItemType { get; set; } = null!;

        public string? UserId { get; set; } 

        public virtual IdentityUser? User { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
