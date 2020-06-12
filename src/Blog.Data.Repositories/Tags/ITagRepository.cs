namespace Blog.Data.Repositories.Tags
{
    using DataAccess;
    using Base;
    using Models;

    public interface ITagRepository : IRepository<Tag>, ITransientRepository
    {
    }
}
