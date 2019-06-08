using AutoMapper;
using Blog.Core.ViewModels.Users;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new List<UserViewModel>();
            var users = this.userService.GetAll();

            foreach(var user in users)
            {
                model.Add(this.mapper.Map<UserViewModel>(user));
            }

            return this.View(model);
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
