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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebCRUDApp.Controllers
{
    public class PessoaController : Controller
    {

        public Context _Context;
        public IConfiguration _config;

        public PessoaController(Context Contexto, IConfiguration config)
        {
            _Context = Contexto;
            _config = config;
        }
        public IActionResult Index()
        {

            string sql = @"select p.id, p.Nome, p.SobreNome, p.DataNascimento, c.NomeCargo from tb_pessoa p
                          join tb_cargo c on c.CargoId = p.CargoId";
                                        
            using(SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var dap = conn.Query<FuncViewModel>(sql);                                                                                                                                 
                return View (dap);                           
            };
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
            listaDeCargos();

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

        // public IActionResult Delete(int id)
        // {
        //     var pessoa = _Context.tb_Pessoa.Find(id);
        //     return View(pessoa);
        // }

        // [HttpPost]
        // public IActionResult Delete(int id, Pessoas p)
        // {
        //     _Context.Remove(p);
        //     _Context.SaveChanges();
        //     return RedirectToAction("Index");
        // }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var p = _Context.tb_Pessoa.Where(x => x.Id == id).FirstOrDefault();
            _Context.Remove(p);
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            string sql = $@"select p.id, p.nome, p.sobrenome, p.datanascimento, c.NomeCargo from tb_pessoa p
                        join tb_cargo c on p.CargoId = c.CargoId
                        where p.id = {id}";
            using(var con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {              
                var dap = con.QueryFirstOrDefault<FuncViewModel>(sql);

                return View(dap);
            }            

        }
        private void listaDeCargos(object CargoSelecionado = null)
        {
            var CargoQuery = from c in _Context.tb_Cargo
                                   orderby c.NomeCargo
                                   select c;
            ViewBag.CargoNome = new SelectList(CargoQuery.AsNoTracking(), "CargoId", "NomeCargo", CargoSelecionado);
        }


    }
}

