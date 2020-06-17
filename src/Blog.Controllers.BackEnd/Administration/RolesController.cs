namespace Blog.Controllers.BackEnd.Administration
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Blog.Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Services.Roles.Models;
    using Blog.ViewModels.BackEnd.Roles;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.Roles;

    [Area("Admin")]
    public class RolesController : BackEndController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService,
            ILogger<RolesController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _roleService = roleService;
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

            var serviceModel = Mapper.Map<CreateRoleServiceModel>(viewModel);

            var result = await _roleService.Create(serviceModel);

            if (!result.Succeeded)
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleService.GetById(id);

            if (role == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<EditRoleViewModel>(role);

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string id, EditRoleViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            var serviceModel = Mapper.Map<EditRoleServiceModel>(viewModel);

            await _roleService.Edit(serviceModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var item = await _roleService.GetById(id);

            var viewModel = Mapper.Map<DetailedRoleViewModel>(item);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _roleService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
