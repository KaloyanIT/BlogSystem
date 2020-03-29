
namespace Blog.Controllers.Controllers.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Admin.Users;
    using Services.User;

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

        public IActionResult Index()
        {
            var model = new List<UserViewModel>();
            var users = _userService.GetAll();

            foreach (var user in users)
            {
                model.Add(_mapper.Map<UserViewModel>(user));
            }

            return View(model);
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
