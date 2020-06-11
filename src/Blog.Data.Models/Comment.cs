namespace Blog.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    using Base;

    public class Comment : BaseDbObject
    {
        public Guid AttachedItemId { get; private set; }

        public string AttachedItemType { get; private set; }

        public string? UserId { get; private set; }

        public IdentityUser? User { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Content { get; private set; }

        public Comment() 
        {
            AttachedItemType = string.Empty;
            Username = string.Empty;
            Email = string.Empty;
            Content = string.Empty;
        }

        public Comment(Guid itemId, string username, string email, string content, string userId = "", string attchementType = "")
        {
            if (itemId == null || itemId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(itemId), "Comment blogId can not be null or empty Guid.");
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username), "Comment username can not be null or empty string.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email), "Comment email can not be null or empty string.");
            }


            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content), "Comment content can not be null or empty string");
            }

            if (!string.IsNullOrWhiteSpace(userId))
            {
                UserId = userId;

                //throw new ArgumentNullException("UserId can not be null or empty string.");
            }
            AttachedItemId = itemId;
            Username = username;
            Email = email;
            Content = content;
            AttachedItemType = attchementType;

        }
    }
}
