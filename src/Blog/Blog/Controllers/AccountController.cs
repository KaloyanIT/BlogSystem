using Blog.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {




            return this.View();
        }


        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await this.signInManager.SignOutAsync();

            if(returnUrl != null)
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.RedirectToAction("Login");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/admin");

            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return this.View();
            }

            var user = await this.userManager.FindByEmailAsync(loginViewModel.Username);

            if(user == null)
            {
                return this.View();
            }

            //var result = await this.

            var result = await this.signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, false);

            if (result.Succeeded)
            {
                return this.Redirect("/admin");
            }

            if (result.RequiresTwoFactor)
            {
                return this.RedirectToPage("./LoginWith2fa", new
                {
                    ReturnUrl = returnUrl,
                    RememberMe = true
                });
            }
            if (result.IsLockedOut)
            {
                return this.RedirectToPage("./Lockout");
            }


            return this.View();
        }
    }
}