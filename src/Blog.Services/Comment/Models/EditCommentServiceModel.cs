namespace Blog.Services.Comment.Models
{
    using System;

    public class EditCommentServiceModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
    }
}
