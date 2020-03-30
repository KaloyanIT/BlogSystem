namespace Blog.Data.Repositories.Keywords
{
    using DataAccess;
    using Base;
    using Models;

    public interface IKeywordRepository : IRepository<Keyword>, ITransientRepository
    {
    }
}
