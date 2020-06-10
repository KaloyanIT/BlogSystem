namespace Blog.Controllers.BackEnd
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;

            var user = User;

            if (!isAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
