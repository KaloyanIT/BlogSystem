namespace Blog.Controllers.ViewComponents
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class GridHeaderViewComponent : ViewComponent
    {
        public GridHeaderViewComponent()
        {

        }

        public Task<IViewComponentResult> InvokeAsync(string title)
        {
            return Task.FromResult((IViewComponentResult)View("Default", title));
        }
    }
}
