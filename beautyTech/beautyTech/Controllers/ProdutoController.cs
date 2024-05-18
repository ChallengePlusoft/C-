using beautyTech.Data;
using beautyTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace beautyTech.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Produto.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto newProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Produto.Add(newProduto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newProduto);
        }

        public IActionResult Edit(int ID)
        {
            var produto = _context.Produto.Find(ID);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public IActionResult Delete(int ID)
        {
            var produto = _context.Produto.Find(ID);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int ID)
        {
            var produto = _context.Produto.Find(ID);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produto.Remove(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
