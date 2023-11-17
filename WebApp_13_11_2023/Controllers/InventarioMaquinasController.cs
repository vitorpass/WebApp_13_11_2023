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
    public class InventarioMaquinasController : Controller
    {
        private readonly DBContext _context;

        public InventarioMaquinasController(DBContext context)
        {
            _context = context;
        }

        // GET: InventarioMaquinas
        public async Task<IActionResult> Index()
        {
              return _context.InventarioMaquinas != null ? 
                          View(await _context.InventarioMaquinas.ToListAsync()) :
                          Problem("Entity set 'DBContext.InventarioMaquinas'  is null.");
        }

        // GET: InventarioMaquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventarioMaquinas == null)
            {
                return NotFound();
            }

            var inventarioMaquinas = await _context.InventarioMaquinas
                .FirstOrDefaultAsync(m => m.id_produto == id);
            if (inventarioMaquinas == null)
            {
                return NotFound();
            }

            return View(inventarioMaquinas);
        }

        // GET: InventarioMaquinas/Create
        public IActionResult Create()
        {
            InventarioMaquinasModel model = new();
            model.ListaProdutos = _context.CadProdutos.ToList();
            model.ListaClientes = _context.CadClientes.ToList();
            return View(model);
        }

        // POST: InventarioMaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_produto,id_cliente,nome_maquina,tipo_maquina,fabricante_maquina,modelo_maquina,data_aquisicao_maquina,custo_aquisicao_maquina,status_maquina,descricao_maquina")] InventarioMaquinas inventarioMaquinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioMaquinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioMaquinas);
        }

        // GET: InventarioMaquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventarioMaquinas == null)
            {
                return NotFound();
            }

            var inventarioMaquinas = await _context.InventarioMaquinas.FindAsync(id);
            if (inventarioMaquinas == null)
            {
                return NotFound();
            }
            return View(inventarioMaquinas);
        }

        // POST: InventarioMaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_produto,id_cliente,nome_maquina,tipo_maquina,fabricante_maquina,modelo_maquina,data_aquisicao_maquina,custo_aquisicao_maquina,status_maquina,descricao_maquina")] InventarioMaquinas inventarioMaquinas)
        {
            if (id != inventarioMaquinas.id_produto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioMaquinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioMaquinasExists(inventarioMaquinas.id_produto))
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
            return View(inventarioMaquinas);
        }

        // GET: InventarioMaquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventarioMaquinas == null)
            {
                return NotFound();
            }

            var inventarioMaquinas = await _context.InventarioMaquinas
                .FirstOrDefaultAsync(m => m.id_produto == id);
            if (inventarioMaquinas == null)
            {
                return NotFound();
            }

            return View(inventarioMaquinas);
        }

        // POST: InventarioMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventarioMaquinas == null)
            {
                return Problem("Entity set 'DBContext.InventarioMaquinas'  is null.");
            }
            var inventarioMaquinas = await _context.InventarioMaquinas.FindAsync(id);
            if (inventarioMaquinas != null)
            {
                _context.InventarioMaquinas.Remove(inventarioMaquinas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioMaquinasExists(int id)
        {
          return (_context.InventarioMaquinas?.Any(e => e.id_produto == id)).GetValueOrDefault();
        }
    }
}
