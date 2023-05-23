using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetMvcRoles.Data;
using AspNetMvcRoles.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspNetMvcRoles.Controllers
{
    [Authorize(Roles = "Admin, Root")]
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Funcinario.Include(f => f.Cargo).Include(f => f.Setor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcinario = await _context.Funcinario
                .Include(f => f.Cargo)
                .Include(f => f.Setor)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (funcinario == null)
            {
                return NotFound();
            }

            return View(funcinario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            ViewData["IdCargo"] = new SelectList(_context.Set<Cargo>(), "IdCargo", "Descricao");
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "Descricao");
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Nome,Endereco,Telefone,Admissao,Salario,Gestor,IdSetor,IdCargo")] Funcinario funcinario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcinario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCargo"] = new SelectList(_context.Set<Cargo>(), "IdCargo", "Descricao", funcinario.IdCargo);
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "Descricao", funcinario.IdSetor);
            return View(funcinario);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcinario = await _context.Funcinario.FindAsync(id);
            if (funcinario == null)
            {
                return NotFound();
            }
            ViewData["IdCargo"] = new SelectList(_context.Set<Cargo>(), "IdCargo", "Descricao", funcinario.IdCargo);
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "Descricao", funcinario.IdSetor);
            return View(funcinario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,Endereco,Telefone,Admissao,Salario,Gestor,IdSetor,IdCargo")] Funcinario funcinario)
        {
            if (id != funcinario.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcinario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncinarioExists(funcinario.Matricula))
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
            ViewData["IdCargo"] = new SelectList(_context.Set<Cargo>(), "IdCargo", "Descricao", funcinario.IdCargo);
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "Descricao", funcinario.IdSetor);
            return View(funcinario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcinario = await _context.Funcinario
                .Include(f => f.Cargo)
                .Include(f => f.Setor)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (funcinario == null)
            {
                return NotFound();
            }

            return View(funcinario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcinario = await _context.Funcinario.FindAsync(id);
            _context.Funcinario.Remove(funcinario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncinarioExists(int id)
        {
            return _context.Funcinario.Any(e => e.Matricula == id);
        }
    }
}
