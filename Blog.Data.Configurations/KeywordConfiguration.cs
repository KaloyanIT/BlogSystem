namespace Blog.Data.Configurations
{
    using Models;
    using Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.ToTable(DataBaseConstants.KEYWORD_TABLE_NAME);
        }
    }
}
