namespace Blog.Data.Repositories.Subscribers
{
    using DataAccess.SqlServer;
    using Models.Context;
    using Microsoft.EntityFrameworkCore;
    using Models.Emails;

    public class SubscriberRepository : SqlServerEntityFrameworkCrudRepository<Subscriber, BlogContext>, ISubscriberRepository
    {
        public SubscriberRepository(BlogContext context) : base(context)
        {
        }

        protected override DbSet<Subscriber> EntityDbSet => Context.Subscribers;
    }
}
