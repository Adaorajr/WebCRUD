using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebCRUDApp.Data.Interfaces;
using WebCRUDApp.Models.Entidades;
using X.PagedList;

namespace WebCRUDApp.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoasRepository _pessoasRepository;
        
        public PessoaController(IPessoasRepository p)
        {
            _pessoasRepository = p;
        }
        public IActionResult Index(int? pagina)
        {
            var p = _pessoasRepository.ListaFunc();
            const int itensPorPagina = 5;
            int numeroPagina = (pagina ?? 1);
            return View(p.ToPagedList(numeroPagina, itensPorPagina));
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
            if (p == null)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(Pessoas p)
        {
            if (ModelState.IsValid)
            {
                _pessoasRepository.Editar(p);
                return RedirectToAction("index");
            }
            listaDeCargos();
            return View();
        }
        //[HttpPost]
        [HttpGet]
        [Route("Pessoa/Delete")]
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
            var CargoQuery = _pessoasRepository.listaCargos();
            ViewBag.CargoNome = new SelectList(CargoQuery, "CargoId", "NomeCargo", CargoSelecionado);
        }
    }
}

