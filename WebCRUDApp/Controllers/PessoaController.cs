using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCRUDApp.Models.Contexto;
using WebCRUDApp.Models.Entidades;
using Dapper;
//using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebCRUDApp.Data.Interfaces;

namespace WebCRUDApp.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoasRepository _pessoasRepository;
        private readonly Context _ctx;

        public PessoaController(IPessoasRepository p, Context context)
        {
            _pessoasRepository = p;
            _ctx = context;
        }
        public IActionResult Index()
        {
            var p = _pessoasRepository.ListaFunc();
            return View(p);

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
                _pessoasRepository.Salvar(p);
                return RedirectToAction("Index");
            }
            listaDeCargos();
            return View(p);
        }

        public IActionResult Edit(int id)
        {
            listaDeCargos();
            var p = _pessoasRepository.Editar(id);
            if(p == null) 
            {
                return RedirectToAction("Index");
            }
            return View(p);
            
        }

        [HttpPost]
        public IActionResult Edit(int id, Pessoas p)
        {
            if (ModelState.IsValid)
            {
                _pessoasRepository.Editar(id, p);
                return RedirectToAction("index");
            }
            listaDeCargos();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            _pessoasRepository.Deletar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var p = _pessoasRepository.Detalhes(id);
            if (p == null)
            {
                return RedirectToAction("Index");   
            }
            return View(p);
        }
        private void listaDeCargos(object CargoSelecionado = null)
        {
            var CargoQuery = from c in _ctx.tb_Cargo
                                   orderby c.NomeCargo
                                   select c;
            ViewBag.CargoNome = new SelectList(CargoQuery.AsNoTracking(),"CargoId", "NomeCargo", CargoSelecionado);
        }
    }
}

