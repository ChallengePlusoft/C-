using beautyTech.Data;
using beautyTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace beutyTech.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Cliente.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente newCliente)
        {
            if (ModelState.IsValid)
            {
                // Obter o último cliente cadastrado
                var ultimoCliente = _context.Cliente
                    .OrderByDescending(c => c.ID_CLIENTE)
                    .FirstOrDefault();

                // Definir o ID_CLIENTE como o último ID mais um, ou 1 se não houver nenhum registro
                newCliente.ID_CLIENTE = (ultimoCliente?.ID_CLIENTE ?? 0) + 1;

                _context.Cliente.Add(newCliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newCliente);
        }

        public IActionResult Edit(int ID)
        {
            var cliente = _context.Cliente.Find(ID);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Delete(int ID)
        {
            var cliente = _context.Cliente.Find(ID);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var cliente = _context.Cliente.Find(ID);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
