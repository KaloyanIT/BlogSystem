namespace Blog.Controllers.Controllers.Admin
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    public class KeywordsController : Controller
    {
        public KeywordsController()
        {

        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
