namespace Blog.Controllers.ViewComponents
{
    using System;
    using System.Threading.Tasks;
    using Blog.ViewModels.FrontEnd;
    using Microsoft.AspNetCore.Mvc;

    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string title, string subTitle, DateTime? creationDate, string? author)
        {
            var headerViewModel = new HeaderViewModel();

            if(string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(subTitle))
            {
                headerViewModel.Title = "Kaloyan's Blog";
                headerViewModel.SubTitle = "Consistency is the key to Success";

                return View(headerViewModel);
            }

            headerViewModel.Title = title;
            headerViewModel.SubTitle = subTitle;
            headerViewModel.CreationDate = creationDate;
            headerViewModel.Author = author;

            return View(headerViewModel);            
        }
    }
}
