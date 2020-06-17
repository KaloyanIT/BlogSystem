namespace Blog.Data.Configurations
{
    using Models;
    using Infrastructure.Constants;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SettingsConfiguration : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.ToTable(DataBaseConstants.SettingsTableName);
        }
    }
}
