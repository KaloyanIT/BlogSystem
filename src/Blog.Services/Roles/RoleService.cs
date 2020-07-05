namespace Blog.Services.Roles
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models;
    using Data.Models.Context;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Models;

    public class RoleService : BaseService, IRoleService
    {
        private readonly BlogContext _blogContext;
        private readonly RoleManager<Role> _roleManager;

        public RoleService(BlogContext blogContext,
            RoleManager<Role> roleManager,
            IMapper mapper, 
            ILogger<RoleService> logger) : base(mapper, logger)
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

        public async Task Edit(EditRoleServiceModel serviceModel)
        {
            var role = await this.GetById(serviceModel.Id);

            role.Name = serviceModel.Name;
            role.Description = serviceModel.Description;
            role.DateModified = DateTime.UtcNow;

            _blogContext.Update(role);
            await _blogContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var role = await this.GetById(id);

            await _roleManager.DeleteAsync(role);
        }
    }
}
