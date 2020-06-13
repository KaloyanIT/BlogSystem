namespace Blog.Controllers.BackEnd
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.Data.Base.Extensions;
    using Blog.Data.Models;
    using Blog.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Users;
    using ViewModels.BackEnd.Users;

    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            var userViewModels = _userService.GetAll()
                .To<UserViewModel>()
                .GetPaged(page, 10);

            return View(userViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var user = _mapper.Map<User>(userViewModel);

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(userViewModel);
            }

            //Add Logic for sending a email with view for setting up password

            return View();
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
