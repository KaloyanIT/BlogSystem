using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.BackEnd.Base
{
    using Microsoft.Extensions.Logging;

    [Area("Admin")]
    public class BackEndController : Controller
    {
        private readonly ILogger<BackEndController> _logger;
        protected int MaxPageSize = 10;

        public BackEndController(ILogger<BackEndController> logger)
        {
            _logger = logger;
        }
    }
}