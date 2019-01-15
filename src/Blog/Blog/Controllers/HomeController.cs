using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            var isAuthenticated = this.User.Identity.IsAuthenticated;            

            if(isAuthenticated)
            {
                if (this.User.IsInRole("Admin"))
                {
                    return this.Redirect("/login");
                }
            }

            return this.View();
        }
    }
}
