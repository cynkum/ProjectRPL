
using System;
using ASPChangTravel.DAL;
using ASPChangTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPChangTravel.Controllers{

    public class KendaraanController:Controller
    {
        private IKendaraan _ken;
        public KendaraanController(IKendaraan ken)
        {
            _ken=ken;

        }
        public IActionResult Index(){
            var data = _ken.GetAll();
            return View(data);
        }

        public IActionResult Create(){
            return View();
        }
        public IActionResult Delete(string no_plat){
            try{
                _ken.Delete(no_plat);
                var data = _ken.GetAll();
                ViewData["pesan"] =
                    "<span class='alert alert-success'>Data Kendaraan berhasil didelete</span>";
                return View("Index",data);
            }catch(Exception ex){
                return Content($"Error: {ex.Message}");
            }
        }

         public IActionResult Details(string no_plat)
        {
            try
            {
                var data = _ken.GetByno_plat(no_plat);
                return View(data);
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }

        }

         [HttpPost]
        public IActionResult Edit(Kendaraan ken){
            try{
                _ken.Update(ken);
                ViewData["pesan"] =
                    "<span class='alert alert-success'>Data Kendaraan berhasil diedit</span>";
                return View("Details");
            }catch(Exception ex){
                return Content($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreatePost(Kendaraan ken){
            try{ 
                _ken.Insert(ken);
                ViewData["pesan"]="<span class='alert alert-success'> Data Added </span>";
                return View("Create");
            }
            catch(Exception ex)
            {
                ViewData["pesan"]=
                $"<span class='alert alert-danger'>Failed to Adding Data, {ex.Message}</span>";
                return Content("Create");
            }
        }
        [HttpPost]
         public IActionResult Search(string keyword){
             var data = _ken.GetAllByMerk(keyword);
             return View("Index", data);
         }
    }
}