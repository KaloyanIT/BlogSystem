using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Blog.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<IdentityUser> GetAll();
    }
}
