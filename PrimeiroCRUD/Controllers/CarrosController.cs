using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrimeiroCRUD.Models;

namespace PrimeiroCRUD.Controllers
{
    public class CarrosController : Controller
    {

        private readonly Contexto _contexto;

        public CarrosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {            
            return View(_contexto.Carros.ToList());
        }

        [HttpGet]
        public IActionResult NovoCarro()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NovoCarro(Carro carro)
        {
            if(ModelState.IsValid)
            {
                _contexto.Add(carro);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        [HttpGet]
        public IActionResult AtualizarCarro (int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(id);

            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarCarro (int id, Carro carro)
        {
            if (id == null)
                return NotFound();
                       
            if (ModelState.IsValid)
            {
                _contexto.Update(carro);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }    

        public IActionResult Detalhes (int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.FirstOrDefault(x => x.CarroId == id);

            return View(carro);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.FirstOrDefault(x => x.CarroId == id);

            return View(carro);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.FirstOrDefault(x => x.CarroId == id);
            _contexto.Remove(carro);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}