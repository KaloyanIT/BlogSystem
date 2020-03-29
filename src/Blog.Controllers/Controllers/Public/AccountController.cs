namespace Blog.Controllers.Controllers.Public
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Public.Account;


    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = new IdentityUser()
            {
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            await _userManager.CreateAsync(user, registerViewModel.Password);

            return View("Login");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/admin");

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Username);

            if (user == null)
            {
                return View();
            }

            //var result = await this.

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect("/admin");
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new
                {
                    ReturnUrl = returnUrl,
                    RememberMe = true
                });
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }


            return View();
        }
    }
}