using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCRUDApp.Models.Contexto;
using WebCRUDApp.Models.Entidades;

namespace WebCRUDApp.Controllers
{
    public class CargoController : Controller
    {
        private Context _ctx;
        public CargoController(Context context)
        {
            _ctx = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cargo cargo)
        {
            var ctx = _ctx.Add(cargo);
            _ctx.SaveChanges();            
            return RedirectToAction("Create", "Pessoa");
        }
        public PartialViewResult partialget() 
        {
            return PartialView("_partialCargo");
        }       
       
    }
}
