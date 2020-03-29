using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers.Controllers
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
