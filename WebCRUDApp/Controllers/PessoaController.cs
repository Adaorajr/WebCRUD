using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCRUDApp.Models.Contexto;
using WebCRUDApp.Models.Entidades;

namespace WebCRUDApp.Controllers
{
    public class PessoaController : Controller
    {
        
        public Context _Context;

        public PessoaController(Context Contexto)
        {
            _Context = Contexto;
        }

        public IActionResult Index()
        {
            var lista = _Context.tb_Pessoa.ToList();
            listaDeCargos();
            //var listaPessoas = _Context.tb_Pessoa.ToList();
            //return View(await _Context.tb_Pessoa.ToListAsync()); ;
            return View(lista);
        }
        public IActionResult Create()
        {
            listaDeCargos();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoas p)
        {
            
            if (ModelState.IsValid)
            {
                
                _Context.Add(p);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(p);
        }

        public IActionResult Edit(int id)
        {
            listaDeCargos();
            var pessoa = _Context.tb_Pessoa.Find(id);
            return View(pessoa);

        }
        [HttpPost]
        public IActionResult Edit(int id, Pessoas p)
        {
            _Context.Update(p);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var pessoa = _Context.tb_Pessoa.Find(id);
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Delete(int id, Pessoas p)
        {
            _Context.Remove(p);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var pessoa = _Context.tb_Pessoa.Find(id);
            return View(pessoa);
        }

        public void listaDeCargos()
        {
            ViewBag.Lista = new SelectList(_Context.tb_Cargo, "CargoId", "NomeCargo");
        }


    }
}

