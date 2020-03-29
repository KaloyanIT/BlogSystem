using AutoMapper;
using Blog.Controllers.ViewModels.Users;
using Blog.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Controllers
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
        
        public async Task<IActionResult> Edit(string id)
        {
            var user = await this.userService.GetById(id);

            if(user == null)
            {
                return this.RedirectToAction("Index");
            }

            var viewModel = this.mapper.Map<EditUserViewModel>(user);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await this.userService.Delete(id);

            return this.Json(new { success = result });
        }
    }
}
