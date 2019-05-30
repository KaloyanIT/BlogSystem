using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            var isAuthenticated = this.User.Identity.IsAuthenticated;

            var user = this.User;

            if(!isAuthenticated)
            {
                return this.Redirect("/account/login");
            }

            return this.View();
        }
    }
}
