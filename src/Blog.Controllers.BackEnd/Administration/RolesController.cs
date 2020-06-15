namespace Blog.Controllers.BackEnd.Administration
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Roles;

    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
