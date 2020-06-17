namespace Blog.Data.Configurations.Emails
{
    using Models.Emails;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Blog.Infrastructure.Constants;

    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.ToTable(DataBaseConstants.SubscriberTableName);
        }
    }
}
