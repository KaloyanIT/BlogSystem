namespace Blog.Services.Base
{
    using System;
    using AutoMapper;
    using Microsoft.Extensions.Logging;

    public class BaseService
    {
        protected IMapper Mapper { get; }
        public ILogger<BaseService> Logger { get; }

        public BaseService(IMapper mapper, ILogger<BaseService> logger)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
