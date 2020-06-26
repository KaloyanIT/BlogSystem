namespace Blog.Controllers.ViewComponents
{
    using System.Threading.Tasks;
    using Infrastructure.Pager;
    using Microsoft.AspNetCore.Mvc;

    public class PagerViewComponent : ViewComponent
    {       
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result, string viewName = "Default")
        {
            return Task.FromResult((IViewComponentResult)View(viewName, result));
        }
    }
}
