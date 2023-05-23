using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetMvcRoles.Data;
using AspNetMvcRoles.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspNetMvcRoles.Controllers
{
    [Authorize(Roles = "Root")]
    public class SedesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SedesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sedes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sedes.ToListAsync());
        }

        // GET: Sedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedes = await _context.Sedes
                .FirstOrDefaultAsync(m => m.IdSede == id);
            if (sedes == null)
            {
                return NotFound();
            }

            return View(sedes);
        }

        // GET: Sedes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSede,Descricao,Aluguel,DataAbertura,ValorDaSede")] Sedes sedes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sedes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sedes);
        }

        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedes = await _context.Sedes.FindAsync(id);
            if (sedes == null)
            {
                return NotFound();
            }
            return View(sedes);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSede,Descricao,Aluguel,DataAbertura,ValorDaSede")] Sedes sedes)
        {
            if (id != sedes.IdSede)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sedes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedesExists(sedes.IdSede))
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
            return View(sedes);
        }

        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedes = await _context.Sedes
                .FirstOrDefaultAsync(m => m.IdSede == id);
            if (sedes == null)
            {
                return NotFound();
            }

            return View(sedes);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sedes = await _context.Sedes.FindAsync(id);
            _context.Sedes.Remove(sedes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedesExists(int id)
        {
            return _context.Sedes.Any(e => e.IdSede == id);
        }
    }
}
