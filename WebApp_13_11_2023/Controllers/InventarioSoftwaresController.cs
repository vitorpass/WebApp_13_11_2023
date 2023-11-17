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
    public class InventarioSoftwaresController : Controller
    {
        private readonly DBContext _context;

        public InventarioSoftwaresController(DBContext context)
        {
            _context = context;
        }

        // GET: InventarioSoftwares
        public async Task<IActionResult> Index()
        {
              return _context.InventarioSoftwares != null ? 
                          View(await _context.InventarioSoftwares.ToListAsync()) :
                          Problem("Entity set 'DBContext.InventarioSoftwares'  is null.");
        }

        // GET: InventarioSoftwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventarioSoftwares == null)
            {
                return NotFound();
            }

            var inventarioSoftwares = await _context.InventarioSoftwares
                .FirstOrDefaultAsync(m => m.id_software == id);
            if (inventarioSoftwares == null)
            {
                return NotFound();
            }

            return View(inventarioSoftwares);
        }

        // GET: InventarioSoftwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioSoftwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_software,id_produto,id_cliente,nome_software,versao_software,fabricante_software,licenca_software,data_aquisicao_software,custo_aquisicao_software,status_software,descricao_software")] InventarioSoftwares inventarioSoftwares)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioSoftwares);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioSoftwares);
        }

        // GET: InventarioSoftwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventarioSoftwares == null)
            {
                return NotFound();
            }

            var inventarioSoftwares = await _context.InventarioSoftwares.FindAsync(id);
            if (inventarioSoftwares == null)
            {
                return NotFound();
            }
            return View(inventarioSoftwares);
        }

        // POST: InventarioSoftwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_software,id_produto,id_cliente,nome_software,versao_software,fabricante_software,licenca_software,data_aquisicao_software,custo_aquisicao_software,status_software,descricao_software")] InventarioSoftwares inventarioSoftwares)
        {
            if (id != inventarioSoftwares.id_software)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioSoftwares);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioSoftwaresExists(inventarioSoftwares.id_software))
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
            return View(inventarioSoftwares);
        }

        // GET: InventarioSoftwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventarioSoftwares == null)
            {
                return NotFound();
            }

            var inventarioSoftwares = await _context.InventarioSoftwares
                .FirstOrDefaultAsync(m => m.id_software == id);
            if (inventarioSoftwares == null)
            {
                return NotFound();
            }

            return View(inventarioSoftwares);
        }

        // POST: InventarioSoftwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventarioSoftwares == null)
            {
                return Problem("Entity set 'DBContext.InventarioSoftwares'  is null.");
            }
            var inventarioSoftwares = await _context.InventarioSoftwares.FindAsync(id);
            if (inventarioSoftwares != null)
            {
                _context.InventarioSoftwares.Remove(inventarioSoftwares);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioSoftwaresExists(int id)
        {
          return (_context.InventarioSoftwares?.Any(e => e.id_software == id)).GetValueOrDefault();
        }
    }
}
