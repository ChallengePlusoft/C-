using beautyTech.Data;
using beautyTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace beutyTech.Controllers
{
    public class EmpresaController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public EmpresaController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Empresa.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empresa newEmpresa)
        {
            if (ModelState.IsValid)
            {
                // Obter a última empresa cadastrada
                var ultimaEmpresa = _context.Empresa
                    .OrderByDescending(e => e.ID_EMPRESA)
                    .FirstOrDefault();

                // Definir o ID_EMPRESA como o último ID mais um, ou 1 se não houver nenhum registro
                newEmpresa.ID_EMPRESA = (ultimaEmpresa?.ID_EMPRESA ?? 0) + 1;

                _context.Empresa.Add(newEmpresa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newEmpresa);
        }


        public IActionResult Edit(int ID)
        {
            var empresa = _context.Empresa.Find(ID);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        public IActionResult Edit(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(empresa).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        public IActionResult Delete(int ID)
        {
            var empresa = _context.Empresa.Find(ID);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var empresa = _context.Empresa.Find(ID);
            if (empresa == null)
            {
                return NotFound();
            }
            _context.Empresa.Remove(empresa);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
