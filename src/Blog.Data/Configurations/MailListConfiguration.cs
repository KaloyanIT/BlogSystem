﻿namespace Blog.Data.Configurations
{
    using Models.Emails;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MailListConfiguration : IEntityTypeConfiguration<MailList>
    {
        public void Configure(EntityTypeBuilder<MailList> builder)
        {
            builder.ToTable("mailLists");

            builder.HasData(
                new MailList("Test", "Test"),
                new MailList("Test1", "Test2")
            );
        }
    }
}