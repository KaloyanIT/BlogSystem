namespace Blog.Controllers.ViewComponents
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
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
            var tagNames = await _tagService.GetAll().Take(tagsToGet)
           .Select(x => x.Name)
           .ToListAsync();

            return (IViewComponentResult)View(templateName, tagNames);
        }
    }
}
