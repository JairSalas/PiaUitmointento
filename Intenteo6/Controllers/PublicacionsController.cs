using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intenteo6.Models.dbModels;
using Microsoft.AspNetCore.Authorization;

namespace Intenteo6.Controllers
{
    [Authorize]
    public class PublicacionsController : Controller
    {
        private readonly DriveDreamDbContext _context;

        public PublicacionsController(DriveDreamDbContext context)
        {
            _context = context;
        }

        // GET: Publicacions
        public async Task<IActionResult> Index()
        {
            var driveDreamDbContext = _context.Publicacions.Include(p => p.ClasificacionNavigation).Include(p => p.IdUsuarioNavigation);
            return View(await driveDreamDbContext.ToListAsync());
        }

        // GET: Publicacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicacions
                .Include(p => p.ClasificacionNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPublicacion == id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return View(publicacion);
        }

        // GET: Publicacions/Create
        public IActionResult Create()
        {
            ViewData["Clasificacion"] = new SelectList(_context.Clasificacions, "IdClasificacion", "IdClasificacion");
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Publicacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPublicacion,Fecha,Titulo,Descripcion,Clasificacion,IdUsuario,Imagen")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Clasificacion"] = new SelectList(_context.Clasificacions, "IdClasificacion", "IdClasificacion", publicacion.Clasificacion);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", publicacion.IdUsuario);
            return View(publicacion);
        }

        // GET: Publicacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicacions.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }
            ViewData["Clasificacion"] = new SelectList(_context.Clasificacions, "IdClasificacion", "IdClasificacion", publicacion.Clasificacion);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", publicacion.IdUsuario);
            return View(publicacion);
        }

        // POST: Publicacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPublicacion,Fecha,Titulo,Descripcion,Clasificacion,IdUsuario,Imagen")] Publicacion publicacion)
        {
            if (id != publicacion.IdPublicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacionExists(publicacion.IdPublicacion))
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
            ViewData["Clasificacion"] = new SelectList(_context.Clasificacions, "IdClasificacion", "IdClasificacion", publicacion.Clasificacion);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", publicacion.IdUsuario);
            return View(publicacion);
        }

        // GET: Publicacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicacions
                .Include(p => p.ClasificacionNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPublicacion == id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return View(publicacion);
        }

        // POST: Publicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacion = await _context.Publicacions.FindAsync(id);
            if (publicacion != null)
            {
                _context.Publicacions.Remove(publicacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacionExists(int id)
        {
            return _context.Publicacions.Any(e => e.IdPublicacion == id);
        }
    }
}
