using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intenteo6.Models.dbModels;

namespace Intenteo6.Controllers
{
    public class FotosCarsController : Controller
    {
        private readonly DriveDreamDbContext _context;

        public FotosCarsController(DriveDreamDbContext context)
        {
            _context = context;
        }

        // GET: FotosCars
        public async Task<IActionResult> Index()
        {
            var driveDreamDbContext = _context.FotosCars.Include(f => f.IdFotoNavigation);
            return View(await driveDreamDbContext.ToListAsync());
        }

        // GET: FotosCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosCar = await _context.FotosCars
                .Include(f => f.IdFotoNavigation)
                .FirstOrDefaultAsync(m => m.IdFoto == id);
            if (fotosCar == null)
            {
                return NotFound();
            }

            return View(fotosCar);
        }

        // GET: FotosCars/Create
        public IActionResult Create()
        {
            ViewData["IdFoto"] = new SelectList(_context.Carros, "IdCar", "IdCar");
            return View();
        }

        // POST: FotosCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFoto,IdCar,Imagen")] FotosCar fotosCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotosCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFoto"] = new SelectList(_context.Carros, "IdCar", "IdCar", fotosCar.IdFoto);
            return View(fotosCar);
        }

        // GET: FotosCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosCar = await _context.FotosCars.FindAsync(id);
            if (fotosCar == null)
            {
                return NotFound();
            }
            ViewData["IdFoto"] = new SelectList(_context.Carros, "IdCar", "IdCar", fotosCar.IdFoto);
            return View(fotosCar);
        }

        // POST: FotosCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFoto,IdCar,Imagen")] FotosCar fotosCar)
        {
            if (id != fotosCar.IdFoto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotosCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotosCarExists(fotosCar.IdFoto))
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
            ViewData["IdFoto"] = new SelectList(_context.Carros, "IdCar", "IdCar", fotosCar.IdFoto);
            return View(fotosCar);
        }

        // GET: FotosCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotosCar = await _context.FotosCars
                .Include(f => f.IdFotoNavigation)
                .FirstOrDefaultAsync(m => m.IdFoto == id);
            if (fotosCar == null)
            {
                return NotFound();
            }

            return View(fotosCar);
        }

        // POST: FotosCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotosCar = await _context.FotosCars.FindAsync(id);
            if (fotosCar != null)
            {
                _context.FotosCars.Remove(fotosCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotosCarExists(int id)
        {
            return _context.FotosCars.Any(e => e.IdFoto == id);
        }
    }
}
