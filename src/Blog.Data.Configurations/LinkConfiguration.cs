namespace Blog.Data.Configurations
{
    using Models.Links;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Blog.Infrastructure.Constants;

    public class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.ToTable(DataBaseConstants.LinkTableName);
        }
    }
}
