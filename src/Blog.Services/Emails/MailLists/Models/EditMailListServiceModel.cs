namespace Blog.Services.Emails.MailLists.Models
{
    using System;
    using Data.Models.Emails;
    using Infrastructure.AutoMapper;

    public class EditMailListServiceModel : IHaveReverseMap<MailList>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
