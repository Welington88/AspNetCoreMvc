using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetMvcRoles.Data;
using AspNetMvcRoles.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Authorization;

namespace AspNetMvcRoles.Controllers
{
    [Authorize(Roles = "Admin, Root")]
    public class RegrasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegrasController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        // GET: Regras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regras.ToListAsync());
        }

        // GET: Regras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regras = await _context.Regras
                .FirstOrDefaultAsync(m => m.IdRegra == id);
            if (regras == null)
            {
                return NotFound();
            }

            return View(regras);
        }

        // GET: Regras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegra,Name")] Regras regras)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = regras.Name;
                role.NormalizedName = regras.Name;
                role.ConcurrencyStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                var roleResult = await _roleManager.CreateAsync(role);

                if (!roleResult.Succeeded)
                {
                    foreach (var erro in roleResult.Errors)
                    {
                        ModelState.AddModelError("Name", erro.ToString());

                        return CreatedAtAction("GetRegras", new { id = regras.IdRegra }, regras);
                    }
                }
                else
                {
                    _context.Add(regras);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(regras);
        }

        // GET: Regras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regras = await _context.Regras.FindAsync(id);
            if (regras == null)
            {
                return NotFound();
            }
            return View(regras);
        }

        // POST: Regras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegra,Name")] Regras regras)
        {
            if (id != regras.IdRegra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regras);
                    await _context.SaveChangesAsync();
                    UpdateRegra(id, regras.Name);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegrasExists(id))
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
            return View(regras);
        }

        public async void UpdateRegra(int id, string nome)
        {
            
                var consult_regras = await _context.Regras.FindAsync(id);
                String nome_regra = nome;
                var role = await _roleManager.FindByNameAsync(consult_regras.Name);
                role.Name = nome_regra;
                role.NormalizedName = nome_regra;
                role.ConcurrencyStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                var roleResult = await _roleManager.UpdateAsync(role);

                if (!roleResult.Succeeded)
                {
                    foreach (var erro in roleResult.Errors)
                    {
                        ModelState.AddModelError("Name", erro.ToString());
                    }
                }

        }

        // GET: Regras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regras = await _context.Regras
                .FirstOrDefaultAsync(m => m.IdRegra == id);
            if (regras == null)
            {
                return NotFound();
            }

            return View(regras);
        }

        // POST: Regras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regras = await _context.Regras.FindAsync(id);

            var role = await _roleManager.FindByNameAsync(regras.Name);
            var roleResult = await _roleManager.DeleteAsync(
                    await _roleManager.FindByIdAsync(role.Id)
                );

            if (!roleResult.Succeeded)
            {
                foreach (var erro in roleResult.Errors)
                {
                    ModelState.AddModelError("Name", erro.ToString());

                    return CreatedAtAction("GetRegras", new { id = regras.IdRegra }, regras);
                }
            }
            else
            {
                _context.Regras.Remove(regras);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RegrasExists(int id)
        {
            return _context.Regras.Any(e => e.IdRegra == id);
        }
    }
}
