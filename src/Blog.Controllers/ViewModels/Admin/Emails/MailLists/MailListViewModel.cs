namespace Blog.Controllers.ViewModels.Admin.Emails.MailLists
{
    using Blog.Data.Models.Emails;
    using Blog.Infrastructure.AutoMapper;

    public class MailListViewModel : IHaveMapFrom<MailList>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
