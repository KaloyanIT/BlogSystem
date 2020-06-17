namespace Blog.Controllers.BackEnd.Administration
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Base.Extensions;
    using Data.Models;
    using Infrastructure.Extensions;
    using Services.Users.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Users;
    using ViewModels.BackEnd.Users;

    [Area("Admin")]
    public class UsersController : BackEndController
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UsersController(IUserService userService,
            UserManager<User> userManager,
            ILogger<UsersController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public IActionResult Index(int page = 1)
        {
            var userViewModels = _userService.GetAll()
                .To<UserViewModel>()
                .GetPaged(page, this.MaxPageSize);

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

            var user = Mapper.Map<User>(userViewModel);

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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var user = await _userService.GetById(id);

            var viewModel = Mapper.Map<EditUserViewModel>(user);

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string id, EditUserViewModel editUserViewModel)
        {
            if (id != editUserViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(editUserViewModel);
            }

            var serviceModel = Mapper.Map<EditUserServiceModel>(editUserViewModel);

            await _userService.Edit(serviceModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<DetailedUserViewModel>(user);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<UserViewModel>(user);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _userService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
