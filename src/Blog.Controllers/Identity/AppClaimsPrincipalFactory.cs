﻿namespace Blog.Controllers.Identity
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Blog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;

    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        public AppClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                ((ClaimsIdentity)principal.Identity!).AddClaims(new[] {
                    new Claim(ClaimTypes.GivenName, user.FirstName)
                });
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                ((ClaimsIdentity)principal.Identity!).AddClaims(new[] {
                     new Claim(ClaimTypes.Surname, user.LastName),
                });
            }

            return principal;
        }
    }
}
