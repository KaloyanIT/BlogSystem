﻿using Microsoft.AspNetCore.Identity;
using System;

namespace Blog.Services.Models.Comments
{
    public class CommentServiceModel
    {
        public Guid Id { get; set; }

        public Guid AttachedItemId { get; set; }

        public string AttachedItemType { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}
