namespace Blog.Data.Repositories.Subscribers
{
    using Models.Emails;
    using DataAccess.SqlServer;
    using Microsoft.EntityFrameworkCore;

    public class SubscriberRepository : SqlServerEntityFrameworkCrudRepository<Subscriber, BlogContext>, ISubscriberRepository
    {
        public SubscriberRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Subscriber> EntityDbSet => Context.Subscribers;
    }
}
