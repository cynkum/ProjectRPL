

using ASPChangTravel.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ASPChangTravel.Controllers{
    public class SupirController:Controller{
        private ISupir _sup;
        public SupirController(ISupir sup)
        {
            _sup= sup;
        }
        public IActionResult Index(){
            var data=_sup.GetAll();
            return View(data);
        }
    }
}