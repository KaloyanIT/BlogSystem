namespace Blog.Controllers.BackEnd.Administration
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.Data.Base.Extensions;
    using Blog.Infrastructure.Extensions;
    using Blog.Services.Roles.Models;
    using Blog.ViewModels.BackEnd.Roles;
    using Microsoft.AspNetCore.Mvc;
    using Services.Roles;

    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            var viewModels = _roleService.GetAll()
                .To<RoleViewModel>()
                .GetPaged(page, 10);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateRoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var serviceModel = _mapper.Map<CreateRoleServiceModel>(viewModel);

            var result = await _roleService.Create(serviceModel);

            if (!result.Succeeded)
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View();
        }
    }
}
