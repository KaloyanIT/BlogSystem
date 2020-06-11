namespace Blog.Controllers.Identity
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            var username = await manager.GetUserNameAsync(user);
            if (username.ToLower(CultureInfo.CurrentCulture).Equals(password.ToLower(CultureInfo.CurrentCulture), StringComparison.OrdinalIgnoreCase))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Username and Password can't be the same.", Code = "SameUserPass" });
            }

            if (password.ToLower(CultureInfo.CurrentCulture).Contains("password", StringComparison.OrdinalIgnoreCase))
            {
                return IdentityResult.Failed(new IdentityError { Description = "The word password is not allowed for the Password.", Code = "PasswordContainsPassword" });
            }

            return IdentityResult.Success;
        }
    }
}
