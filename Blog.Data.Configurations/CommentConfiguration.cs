namespace Blog.Data.Configurations
{
    using Models;
    using Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(DataBaseConstants.COMMENT_TABLE_NAME);
        }
    }
}
