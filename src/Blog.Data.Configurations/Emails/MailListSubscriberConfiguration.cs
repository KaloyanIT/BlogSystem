namespace Blog.Data.Configurations.Emails
{
    using Models.Emails;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Infrastructure.Constants;

    public class MailListSubscriberConfiguration : IEntityTypeConfiguration<MailListSubscriber>
    {
        public void Configure(EntityTypeBuilder<MailListSubscriber> builder)
        {
            builder.ToTable(DataBaseConstants.MailListSubscribeTableName);

            builder.HasKey(bc => new { bc.MailListId, bc.SubscriberId });

            builder.HasOne(bc => bc.MailList!)
                .WithMany(b => b.MailListSubscribers)
                .HasForeignKey(bc => bc.MailListId);

            builder.HasOne(bc => bc.Subscriber!)
                 .WithMany(c => c.MailListSubscriber)
                 .HasForeignKey(bc => bc.SubscriberId);
        }
    }
}
