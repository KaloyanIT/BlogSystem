namespace Blog.DataAccess
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : IDbObject
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task Save(T saveThis);

        Task Delete(T deleteThis);

    }
}
