namespace Blog.Controllers.ViewModels.Admin.Emails.MailLists
{
    using System;
    using Blog.Services.Emails.MailLists.Models;
    using Data.Models.Emails;
    using Infrastructure.AutoMapper;

    public class EditMailListViewModel : IHaveMapFrom<MailList>, IHaveMapTo<EditMailListServiceModel>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
