using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intenteo6.Models.dbModels;
using Intenteo6.Models;

namespace Intenteo6.Controllers
{
    public class CarrosController : Controller
    {
        private readonly DriveDreamDbContext _context;

        public CarrosController(DriveDreamDbContext context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var driveDreamDbContext = _context.Carros.Include(c => c.IdmodeloNavigation).Include(c => c.MarcaNavigation);
            return View(await driveDreamDbContext.ToListAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.IdmodeloNavigation)
                .Include(c => c.MarcaNavigation)
                .FirstOrDefaultAsync(m => m.IdCar == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            ViewData["Idmodelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo");
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca");
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCar,Name,Año,Idmodelo,Precio,Marca")] CarroHr carro)
        {

            if (ModelState.IsValid)
            {
                Carro carro1 = new Carro
                {
                    Name = carro.Name,
                    Año = carro.Año,
                    Idmodelo = carro.Idmodelo,
                    Precio = carro.Precio,
                    Marca = carro.Marca
                };
               



                _context.Carros.Add(carro1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idmodelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", carro.Idmodelo);
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", carro.Marca);
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            ViewData["Idmodelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", carro.Idmodelo);
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", carro.Marca);
            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCar,Name,Año,Idmodelo,Precio,Marca")] Carro carro)
        {
            if (id != carro.IdCar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.IdCar))
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
            ViewData["Idmodelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", carro.Idmodelo);
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "IdMarca", carro.Marca);
            return View(carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.IdmodeloNavigation)
                .Include(c => c.MarcaNavigation)
                .FirstOrDefaultAsync(m => m.IdCar == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro != null)
            {
                _context.Carros.Remove(carro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.IdCar == id);
        }
    }
}
