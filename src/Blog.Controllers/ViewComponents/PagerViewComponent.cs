namespace Blog.Controllers.ViewComponents
{
    using System.Threading.Tasks;
    using Blog.Infrastructure.Pager;
    using Microsoft.AspNetCore.Mvc;

    public class PagerViewComponent : ViewComponent
    {       
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
