using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Blog.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<IdentityUser> GetAll();

        Task<IdentityUser> GetById(string id);

        Task<bool> Delete(string id);
    }
}
