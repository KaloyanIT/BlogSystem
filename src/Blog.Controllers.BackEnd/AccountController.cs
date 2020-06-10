namespace Blog.Controllers.BackEnd
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return this.View();
        }
    }
}
