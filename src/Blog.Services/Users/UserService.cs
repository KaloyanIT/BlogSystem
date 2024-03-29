﻿namespace Blog.Services.Users
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models;
    using Data.Models.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Models;

    public class UserService : BaseService, IUserService
    {
        private readonly BlogContext _blogContext;

        public UserService(BlogContext blogContext,
            IMapper mapper, 
            ILogger<UserService> logger) : base(mapper, logger)
        {
            _blogContext = blogContext;
        }

        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            var user = await _blogContext.Set<User>().FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return false;
            }

            try
            {
                _blogContext.Set<User>().Remove(user);
                await _blogContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task Edit(EditUserServiceModel serviceModel)
        {
            var user = await _blogContext.Users.FirstOrDefaultAsync(x => x.Id == serviceModel.Id);

            if(user == null)
            {
                //
                return;
            }

            user.FirstName = serviceModel.FirstName;
            user.LastName = serviceModel.LastName;
            user.PhoneNumber = serviceModel.PhoneNumber;

            _blogContext.Attach(user);
            await _blogContext.SaveChangesAsync();
        }

        public IQueryable<User> GetAll()
        {
            var result = _blogContext.Users.AsQueryable();

            return result;
        }

        public async Task<User?> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null!;
            }

            var user = await _blogContext.Set<User>().FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<string> GetIdByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null!;
            }

            var user = await GetAll().FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                return null!;
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
