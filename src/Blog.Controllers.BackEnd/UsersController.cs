namespace Blog.Controllers.BackEnd
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.Data.Base.Extensions;
    using Blog.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Services.Users;
    using ViewModels.BackEnd.Users;

    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            var userViewModels = _userService.GetAll()
                .To<UserViewModel>()
                .GetPaged(page, 10);            

            return View(userViewModels);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = _mapper.Map<EditUserViewModel>(user);

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.Delete(id);

            return Json(new { success = result });
        }
    }
}
