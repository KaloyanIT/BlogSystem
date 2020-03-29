namespace Blog.Services.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public interface IUserService
    {
        IQueryable<IdentityUser> GetAll();

        Task<IdentityUser> GetById(string id);

        Task<string> GetUsernameById(string id);

        Task<string> GetIdByUsername(string username);

        Task<bool> Delete(string id);
    }
}
