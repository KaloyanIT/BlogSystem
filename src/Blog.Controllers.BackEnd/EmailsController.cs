namespace Blog.Controllers.BackEnd
{
    using Microsoft.AspNetCore.Mvc;


    [Area("Admin")]
    public class EmailsController : Controller
    {
        public EmailsController()
        {

        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
