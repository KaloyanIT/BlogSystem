namespace Blog.Controllers.Controllers.Admin
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
