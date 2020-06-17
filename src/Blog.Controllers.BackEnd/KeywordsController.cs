namespace Blog.Controllers.BackEnd
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
