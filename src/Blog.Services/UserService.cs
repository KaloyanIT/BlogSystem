using Blog.Data;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly BlogContext blogContext;

        public UserService(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var user = await this.blogContext.Set<IdentityUser>().FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return false;
            }

            try
            {
                this.blogContext.Set<IdentityUser>().Remove(user);
                await this.blogContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public IQueryable<IdentityUser> GetAll()
        {
            var result = this.blogContext.Users.AsQueryable();

            return result;
        }

        public async Task<IdentityUser> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var user = await this.blogContext.Set<IdentityUser>().FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
    }
}
