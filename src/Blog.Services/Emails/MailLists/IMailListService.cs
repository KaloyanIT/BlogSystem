namespace Blog.Services.Emails.MailLists
{
    using System.Linq;
    using Base;
    using Data.Models.Emails;

    public interface IMailListService : IService
    {
        IQueryable<MailList> GetAll();
    }
}
