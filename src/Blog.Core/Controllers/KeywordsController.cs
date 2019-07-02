using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

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
