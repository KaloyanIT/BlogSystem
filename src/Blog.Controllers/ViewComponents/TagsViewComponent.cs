namespace Blog.Controllers.ViewComponents
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.Tags;

    public class TagsViewComponent : ViewComponent
    {
        private readonly ITagService _tagService;

        public TagsViewComponent(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int tagsToGet, string templateName = "Default")
        {
            var tagNames = _tagService.GetAll().Take(tagsToGet)
                .Select(x => x.Name)
                .ToList();

            return (IViewComponentResult)View(templateName, tagNames);
        }
    }
}
