namespace Blog.Services.Users
{
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Microsoft.AspNetCore.Identity;

    public interface IUserService : IService
    {
        IQueryable<IdentityUser> GetAll();

        Task<IdentityUser> GetById(string id);

        Task<string> GetUsernameById(string id);

        Task<string> GetIdByUsername(string username);

        Task<bool> Delete(string id);
    }
}
