namespace Blog.Controllers.FrontEnd
{
    using System.Threading.Tasks;
    using Data.Models;
    using EmailService;
    using EmailService.Models;
    using Infrastructure.Emails;
    using ViewModels.FrontEnd.Account;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;


    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailsService _emailsService;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailsService emailsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailsService = emailsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            //var message = new RegistrationEmailMessage(new string[] { "testest@pesho.ckk" }, "Confirmation email link", "COntent", "");
            //await _emailsService.SendEmailAsync(message);
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

            var user = new User()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(registerViewModel);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);

            var message = new RegistrationEmailMessage(new string[] { user.Email }, "Confirmation email link", "Confirm your registration", confirmationLink);
            await _emailsService.SendEmailAsync(message);

            await _userManager.AddToRoleAsync(user, "Member");

            return View("/Views/Login/Login.cshtml");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SuccessRegistration()
        {
            return View();
        }
    }
}