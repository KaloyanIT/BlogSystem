using Blog.Data.Models.Comments;

namespace Blog.ViewModels.FrontEnd.Comments
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Org.BouncyCastle.Bcpg.OpenPgp;

    public class CommentDetailedViewModel : IHaveMapFrom<Comment>
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string Content { get; set; } = null!;

        public string Username { get; set; }
    }
}
