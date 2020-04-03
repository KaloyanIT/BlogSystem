﻿
namespace Blog.Data.Seeders
{
    using System;
    using System.Threading.Tasks;
    using Blog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class MainSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }

            var userEmail = configuration.GetSection("UserSettings")["UserEmail"];

            var powerUser = new User
            {
                UserName = userEmail,
                Email = userEmail,
                FirstName = "Test",
                LastName = "Test"
            };

            string userPassword = configuration.GetSection("UserSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(powerUser, userPassword);

                if (createPowerUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}