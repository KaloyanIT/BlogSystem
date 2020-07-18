namespace Blog.Data.Configurations.Meta
{
    using Blog.Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models.Meta;

    public class OpenGraphConfiguration : IEntityTypeConfiguration<OpenGraph>
    {
        public void Configure(EntityTypeBuilder<OpenGraph> builder)
        {
            builder.ToTable(DataBaseConstants.OpenGraphTableName);
        }
    }
}
