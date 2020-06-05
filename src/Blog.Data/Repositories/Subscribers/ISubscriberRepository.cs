namespace Blog.Data.Repositories.Subscribers
{
    using Base;
    using Models.Emails;
    using DataAccess;

    public interface ISubscriberRepository : IRepository<Subscriber>, ITransientRepository
    {
    }
}
