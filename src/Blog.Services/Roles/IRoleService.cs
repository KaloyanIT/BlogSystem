namespace Blog.Services.Roles
{
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Data.Models;

    public interface IRoleService : IService
    {
        IQueryable<Role> GetAll();

        Task<Role> GetById(string id);
    }
}
