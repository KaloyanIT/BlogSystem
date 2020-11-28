namespace Blog.ViewModels.FrontEnd.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Comments;
    using Infrastructure.AutoMapper;
    using Services.Comment.Models;

    public class CreateCommentViewModel : IHaveMapTo<CommentServiceModel>
    {
        public string AttachedItemId { get; set; }

        public string CommentItemType { get; set; }

        [Required]
        [NotLike(Text = "YTest")]
        public string Content { get; set; } = null!;
    }

    public class NotLikeAttribute : ValidationAttribute
    {
        public string Text { get; set; }

        public NotLikeAttribute()
        {
            
        }

        protected override ValidationResult IsValid(object value,
            System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (object.Equals(value, Text))
            {
                // here i am verifying whether the 2 values are equal
                // here you could do any custom validation you like
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success!;
        }
    }
}
