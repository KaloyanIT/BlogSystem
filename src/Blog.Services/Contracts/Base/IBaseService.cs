using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services.Contracts.Base
{
    public interface IBaseService<T> where T : class
    {
        Task Save(T value);

        IQueryable<T> GetAll();

        Task<T> GetById(Guid? id);

        Task<T> DeleteById(Guid? id);

    }
}
