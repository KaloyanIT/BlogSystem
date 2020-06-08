namespace Blog.Data.Repositories.MailLists
{
    using Models.Emails;
    using DataAccess;
    using Data.Base;

    public interface IMailListRepository : IRepository<MailList>, ITransientRepository
    {
    }
}
