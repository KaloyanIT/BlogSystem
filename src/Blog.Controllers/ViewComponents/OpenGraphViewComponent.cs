using System;
using System.Threading.Tasks;
using Blog.ViewModels.FrontEnd.Meta;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.ViewComponents
{
    public class OpenGraphViewComponent : ViewComponent
    {
        public OpenGraphViewComponent()
        {

        }

        public Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            //Get it
            var viewModel = new OpenGraphViewModel();

            return Task.FromResult((IViewComponentResult)View(viewModel));
        }
    }
}
