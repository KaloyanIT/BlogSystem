namespace Blog.Controllers.ViewComponents
{
    using System;
    using System.Threading.Tasks;
    using Services.Meta.OpenGraphs;
    using ViewModels.FrontEnd.Meta;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;

    public class OpenGraphViewComponent : ViewComponent
    {
        private readonly IOpenGraphService _openGraphService;
        private readonly IMapper _mapper;

        public OpenGraphViewComponent(IOpenGraphService openGraphService, IMapper mapper)
        {
            _openGraphService = openGraphService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? attachedItemId = null)
        {
            if(!attachedItemId.HasValue)
            {
                //TODO: Use it for Default Value
                return View(new OpenGraphViewModel());
            }

            var openGraph = await _openGraphService.GetByAttachedItemId(attachedItemId.Value);

            if(openGraph == null)
            {
                return View(new OpenGraphViewModel());
            }

            var viewModel = _mapper.Map<OpenGraphViewModel>(openGraph);

            return View(viewModel);
        }
    }
}
