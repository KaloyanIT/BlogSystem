namespace Blog.Controllers.BackEnd
{
    using AutoMapper;
    using Base;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;


    [Area("Admin")]
    public class EmailsController : BackEndController
    {
        public EmailsController(ILogger<BackEndController> logger,
            IMapper mapper) : base(logger, mapper)
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }

        
    }
}
