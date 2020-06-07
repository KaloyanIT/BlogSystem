namespace Blog.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class BlogPostTagConfiguration : IEntityTypeConfiguration<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.ToTable("blogPostTags");

            builder.HasKey(bc => new { bc.BlogPostId, bc.TagId });

            builder.HasOne(bc => bc.BlogPost!)
                .WithMany(b => b.BlogTags)
                .HasForeignKey(bc => bc.BlogPostId);

            builder.HasOne(bc => bc.Tag!)
                .WithMany(c => c.BlogPostTag)
                .HasForeignKey(bc => bc.TagId);
        }
    }
}
