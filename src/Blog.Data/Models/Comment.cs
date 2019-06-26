using Blog.Data.Base;
using System;

namespace Blog.Data.Models
{
    public class Comment : BaseDbObject
    {
        public Guid AttachedItemId { get; set; }

        public string AttachedItemType { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public Comment() { }

        public Comment(Guid itemId, string username, string email, string content)
        {
            if(itemId == null || itemId == Guid.Empty)
            {
                throw new ArgumentNullException("Comment blogId can not be null or empty Guid.");
            }

            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Comment username can not be null or empty string.");
            }

            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Comment email can not be null or empty string.");
            }

            if(string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("Comment content can not be null or empty string");
            }

            this.AttachedItemId = itemId;
            this.Username = username;
            this.Email = email;
            this.Content = content;
        }
    }
}
