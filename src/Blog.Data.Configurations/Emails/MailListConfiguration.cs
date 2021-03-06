﻿namespace Blog.Data.Configurations.Emails
{
    using Models.Emails;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Infrastructure.Constants;

    public class MailListConfiguration : IEntityTypeConfiguration<MailList>
    {
        public void Configure(EntityTypeBuilder<MailList> builder)
        {
            builder.ToTable(DataBaseConstants.MailListTableName);
        }
    }
}
