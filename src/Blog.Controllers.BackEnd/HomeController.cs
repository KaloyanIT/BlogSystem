namespace Blog.Controllers.BackEnd
{
    using AutoMapper;
    using Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Area("Admin")]
    public class HomeController : BackEndController
    {
        public HomeController(ILogger<BackEndController> logger,
            IMapper mapper) : base(logger, mapper)
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            var isAuthenticated = User.Identity.IsAuthenticated;

            var user = User;

            if (!isAuthenticated)
            {
                return Redirect("/login");
            }

            return View();
        }
    }
}
