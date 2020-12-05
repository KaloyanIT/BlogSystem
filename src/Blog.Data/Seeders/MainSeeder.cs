namespace Blog.Data.Seeders
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Blog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class MainSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider, [NotNull]IConfiguration configuration)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();         

            var userEmail = configuration.GetSection("UserSettings")["UserEmail"];

            var powerUser = new User
            {
                UserName = userEmail,
                Email = userEmail,
                FirstName = "Test",
                LastName = "Test",
                CreatedBy = Guid.Empty.ToString()
            };

            string userPassword = configuration.GetSection("UserSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                await UserManager.CreateAsync(powerUser, userPassword);               
            }

            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new Role() { Name = roleName, Description = "Initial", CreatedBy = powerUser.Id});
                }
            }

            await UserManager.AddToRoleAsync(powerUser, "Admin");
        }
    }
}