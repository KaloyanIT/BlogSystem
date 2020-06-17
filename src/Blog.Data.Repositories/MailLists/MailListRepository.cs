namespace Blog.Data.Repositories.MailLists
{
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;
    using Models.Context;
    using Models.Emails;

    public class MailListRepository : SqlServerEntityFrameworkCrudRepository<MailList, BlogContext>, IMailListRepository
    {
        public MailListRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<MailList> EntityDbSet => Context.MailLists;
    }
}
