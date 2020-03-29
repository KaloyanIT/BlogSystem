namespace Blog.Controllers.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;

            var user = User;

            if (!isAuthenticated)
            {
                return Redirect("/account/login");
            }

            return View();
        }
    }
}
