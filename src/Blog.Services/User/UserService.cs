namespace Blog.Services.User
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Data;

    public class UserService : IUserService
    {
        private readonly BlogContext _blogContext;

        public UserService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var user = await _blogContext.Set<IdentityUser>().FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return false;
            }

            try
            {
                _blogContext.Set<IdentityUser>().Remove(user);
                await _blogContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public IQueryable<IdentityUser> GetAll()
        {
            var result = _blogContext.Users.AsQueryable();

            return result;
        }

        public async Task<IdentityUser> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var user = await _blogContext.Set<IdentityUser>().FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<string> GetIdByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            var user = await GetAll().FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public async Task<string> GetUsernameById(string id)
        {
            var user = await GetById(id);

            if (user == null)
            {
                return string.Empty;
            }

            return user.UserName;
        }
    }
}
