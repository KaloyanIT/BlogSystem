namespace Blog.Data.Repositories.MailLists
{
    using Models.Emails;
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;

    public class MailListRepository : SqlServerEntityFrameworkCrudRepository<MailList, BlogContext>, IMailListRepository
    {
        public MailListRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<MailList> EntityDbSet => Context.MailLists;
    }
}
