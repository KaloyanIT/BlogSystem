namespace Blog.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class BlogPostKeywordConfiguration : IEntityTypeConfiguration<BlogPostKeyword>
    {
        public void Configure(EntityTypeBuilder<BlogPostKeyword> builder)
        {
            builder.ToTable("blogPostKeywords");

            builder.HasKey(bc => new { bc.BlogPostId, bc.KeywordId });

            builder.HasOne(bc => bc.BlogPost!)
                .WithMany(b => b.BlogKeywords)
                .HasForeignKey(bc => bc.BlogPostId);

            builder.HasOne(bc => bc.Keyword!)
                .WithMany(c => c.BlogKeywords)
                .HasForeignKey(bc => bc.KeywordId);
        }
    }
}
