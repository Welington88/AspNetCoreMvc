using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetMvcRoles.Data;
using AspNetMvcRoles.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetMvcRoles.Controllers
{
    [Authorize(Roles = "Admin, Root")]
    public class CargosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cargos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cargo.Include(c => c.Setor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .Include(c => c.Setor)
                .FirstOrDefaultAsync(m => m.IdCargo == id);
            if (cargo == null)
            {
                return NotFound();
            }
            
            return View(cargo);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao");
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCargo,Descricao,IdSetor")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao", cargo.IdSetor);
            return View(cargo);
        }

        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao", cargo.IdSetor);
            return View(cargo);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCargo,Descricao,IdSetor")] Cargo cargo)
        {
            if (id != cargo.IdCargo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.IdCargo))
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
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao", cargo.IdSetor);
            return View(cargo);
        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .Include(c => c.Setor)
                .FirstOrDefaultAsync(m => m.IdCargo == id);
            if (cargo == null)
            {
                return NotFound();
            }
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao", cargo.IdSetor);
            return View(cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo = await _context.Cargo.FindAsync(id);
            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
            return _context.Cargo.Any(e => e.IdCargo == id);
        }
    }
}
