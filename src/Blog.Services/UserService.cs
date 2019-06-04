using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Data;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Blog.Services
{
    public class UserService : IUserService
    {
        private readonly BlogContext blogContext;

        public UserService(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public IQueryable<IdentityUser> GetAll()
        {
            var result = this.blogContext.Users.AsQueryable();

            return result;
        }
    }
}
