using _01_Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_Intro.Controllers
{
    public class ItemsController : Controller {
        public IActionResult Overview()
        {
            Item item = new Item(){Name = "Keyboard"};
            return View(item);
        }

        public IActionResult Parameter(int id) {
            return Content("parameter value  = " + id);
        }
    }
}