using System;
using Blog.Data.Base;

namespace Blog.Data.Models.Comments
{
    public class Comment : BaseDbObject
    {
        public Guid AttachedItemId { get; private set; }

        public CommentItemType CommentItemType { get; private set; }

        public string? UserId { get; private set; }

        public User? User { get; private set; }

        public int Rating { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Content { get; private set; }

        public Comment()
        {
            Username = string.Empty;
            Email = string.Empty;
            Content = string.Empty;
        }

        public Comment(Guid itemId, CommentItemType itemType, string username, string email, string content, string userId = "")
        {
            if (itemId == Guid.Empty)
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

            //if (!string.IsNullOrWhiteSpace(userId))
            //{
            //    //UserId = userId;

            //    throw new ArgumentNullException(nameof(userId), "UserId can not be null or empty string.");
            //}

            AttachedItemId = itemId;
            Username = username;
            Email = email;
            Content = content;
            CommentItemType = itemType;
            UserId = userId;
            Rating = 0;
        }

        public void VoteUp()
        {
            Rating = Rating + 1;
        }

        public void VoteDown()
        {
            Rating = Rating + 1;
        }
    }
}
