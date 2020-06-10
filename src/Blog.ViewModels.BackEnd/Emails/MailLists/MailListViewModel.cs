namespace Blog.ViewModels.BackEnd.Emails.MailLists
{
    using System;
    using System.ComponentModel;
    using Blog.Data.Models.Emails;
    using Blog.Infrastructure.AutoMapper;

    public class MailListViewModel : IHaveMapFrom<MailList>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Last Modified")]
        public DateTime? DateModified { get; set; }
    }
}
