namespace Blog.Controllers.Controllers.Public
{
    using System.Globalization;
    using System.Threading.Tasks;
    using Blog.Controllers.ViewModels.Public.Account;
    using Blog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("account/[action]")]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        

        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl ?? "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
        {
            //returnUrl = returnUrl ?? Url.Content("~/admin");
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Username);

            var result = await _signInManager.PasswordSignInAsync(user.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                var forgotPassLink = Url.Action("ForgotPassword", "Account", new { }, Request.Scheme);
                var content = string.Format(CultureInfo.CurrentCulture, "Your account is locked out, to reset your password, please click this link: {0}", forgotPassLink);

                //var message = new Message(new string[] { logi.Email }, „Locked out account information“, content, null);
                //await _emailSender.SendEmailAsync(message);

                ModelState.AddModelError("", "The account is locked out");
                return View();
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Email address is not confirmed");
            }

            ModelState.AddModelError("", "Invalid UserName or Password");
            return View();
        }

        public async Task<IActionResult> Logout(string? returnUrl)
        {
            await _signInManager.SignOutAsync();

            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");

        }
    }
}
