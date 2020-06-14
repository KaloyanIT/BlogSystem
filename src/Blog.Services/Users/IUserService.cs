namespace Blog.Services.Users
{
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Users.Models;
    using Data.Models;

    public interface IUserService : IService
    {
        Task Edit(EditUserServiceModel serviceModel);

        IQueryable<User> GetAll();

        Task<User> GetById(string id);

        Task<string> GetUsernameById(string id);

        Task<string> GetIdByUsername(string username);

        Task<bool> Delete(string id);
    }
}
