
using Microsoft.AspNetCore.Mvc;

namespace ASPChangTravel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        public IActionResult HalamanPemesanan(){
            return View();
        }
        
    }
}