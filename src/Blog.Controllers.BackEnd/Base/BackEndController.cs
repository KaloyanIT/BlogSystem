using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.BackEnd.Base
{
    using System;
    using AutoMapper;
    using Microsoft.Extensions.Logging;

    [Area("Admin")]
    public class BackEndController : Controller
    {
        protected ILogger<BackEndController> Logger { get; }
        protected IMapper Mapper { get; }

        protected int MaxPageSize { get; } = 10;

        public BackEndController(ILogger<BackEndController> logger, IMapper mapper)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger is null.");
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "AutoMapper is null.");
        }
    }
}