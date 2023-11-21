using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_13_11_2023.Data;
using WebApp_13_11_2023.Models;

namespace WebApp_13_11_2023.Controllers
{
    public class CadProdutosController : Controller
    {
        private readonly DBContext _context;

        public CadProdutosController(DBContext context)
        {
            _context = context;
        }

        // GET: CadProdutos
        public async Task<IActionResult> Index()
        {
              return _context.CadProdutos != null ? 
                          View(await _context.CadProdutos.ToListAsync()) :
                          Problem("Entity set 'DBContext.CadProdutos'  is null.");
        }

        // GET: CadProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadProdutos == null)
            {
                return NotFound();
            }

            var cadProdutos = await _context.CadProdutos
                .FirstOrDefaultAsync(m => m.id_produto == id);
            if (cadProdutos == null)
            {
                return NotFound();
            }

            return View(cadProdutos);
        }

        // GET: CadProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_produto,nome_produto,descricao_produto,preco_produto")] CadProdutos cadProdutos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadProdutos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadProdutos);
        }

        // GET: CadProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadProdutos == null)
            {
                return NotFound();
            }

            var cadProdutos = await _context.CadProdutos.FindAsync(id);
            if (cadProdutos == null)
            {
                return NotFound();
            }
            return View(cadProdutos);
        }

        // POST: CadProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_produto,nome_produto,descricao_produto,preco_produto")] CadProdutos cadProdutos)
        {
            if (id != cadProdutos.id_produto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadProdutos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadProdutosExists(cadProdutos.id_produto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadProdutos);
        }

        // GET: CadProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadProdutos == null)
            {
                return NotFound();
            }

            var cadProdutos = await _context.CadProdutos
                .FirstOrDefaultAsync(m => m.id_produto == id);
            if (cadProdutos == null)
            {
                return NotFound();
            }

            return View(cadProdutos);
        }

        // POST: CadProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadProdutos == null)
            {
                return Problem("Entity set 'DBContext.CadProdutos'  is null.");
            }
            var cadProdutos = await _context.CadProdutos.FindAsync(id);
            if (cadProdutos != null)
            {
                _context.CadProdutos.Remove(cadProdutos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadProdutosExists(int id)
        {
          return (_context.CadProdutos?.Any(e => e.id_produto == id)).GetValueOrDefault();
        }
    }
}
