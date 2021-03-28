namespace Blog.Data.Repositories.ContactData
{
    using Base;
    using DataAccess;
    using Models;

    public interface IContactDataRepository : IRepository<ContactData>, ITransientRepository
    {
    }
}
