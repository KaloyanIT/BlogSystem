namespace Blog.Services.Roles
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models.Context;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RoleService : IRoleService
    {
        private readonly BlogContext _blogContext;

        public RoleService(BlogContext blogContext)
        {
            this._blogContext = blogContext;
        }

        public IQueryable<Role> GetAll()
        {
            var items = _blogContext.Roles;

            return items;
        }

        public Task<Role> GetById(string id)
        {
            var role = this.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            return role;
        }
    }
}
