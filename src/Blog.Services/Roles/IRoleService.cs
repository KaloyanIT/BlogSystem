namespace Blog.Services.Roles
{
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Models;

    public interface IRoleService : IService
    {
        Task<IdentityResult> Create(CreateRoleServiceModel serviceModel);

        IQueryable<Role> GetAll();

        Task<Role?> GetById(string id);

        Task Edit(EditRoleServiceModel serviceModel);

        Task Delete(string id);
    }
}
