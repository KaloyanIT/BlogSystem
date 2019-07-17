using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
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
