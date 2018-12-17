using Blog.Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        public async Task<IActionResult> Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserViewModel userViewModel, string returnUrl)
        {
            return this.View();
        }
    }
}
