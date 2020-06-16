namespace Blog.Services.Roles
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using Data.Models.Context;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class RoleService : IRoleService
    {
        private readonly BlogContext _blogContext;
        private readonly RoleManager<Role> _roleManager;

        public RoleService(BlogContext blogContext, RoleManager<Role> roleManager)
        {
            _blogContext = blogContext;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> Create(CreateRoleServiceModel serviceModel)
        {
            var role = new Role(serviceModel.Name, serviceModel.Description);

            var result = await _roleManager.CreateAsync(role);

            return result;
        }

        public IQueryable<Role> GetAll()
        {
            var items = _blogContext.Roles;

            return items;
        }

        public async Task<Role> GetById(string id)
        {
            var role = await GetAll().FirstOrDefaultAsync(x => x.Id == id);

            return role;
        }
    }
}
