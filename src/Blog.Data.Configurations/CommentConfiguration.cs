
namespace Blog.Data.Configurations
{
    using System;
    using Models.Comments;
    using Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(DataBaseConstants.CommentTableName);

            builder.Property(e => e.CommentItemType)
                .HasConversion(
                    v => v.ToString(),
                    v => (CommentItemType)Enum.Parse(typeof(CommentItemType), v)
                );
        }
    }
}
