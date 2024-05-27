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
    [Authorize(Roles = "Admin")]
    public class AplicationUsersController : Controller
    {
        private readonly DriveDreamDbContext _context;

        public AplicationUsersController(DriveDreamDbContext context)
        {
            _context = context;
        }

        // GET: AplicationUsers
        public async Task<IActionResult> Index()
        {
            var driveDreamDbContext = _context.Users.Include(a => a.GenderNavigation);
            return View(await driveDreamDbContext.ToListAsync());
        }

        // GET: AplicationUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicationUser = await _context.Users
                .Include(a => a.GenderNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicationUser == null)
            {
                return NotFound();
            }

            return View(aplicationUser);
        }

        // GET: AplicationUsers/Create
        public IActionResult Create()
        {
            ViewData["Gender"] = new SelectList(_context.Generos, "IdGenero", "IdGenero");
            return View();
        }

        // POST: AplicationUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName,MLastName,Biography,Gender,ImageProfile,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AplicationUser aplicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aplicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Gender"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", aplicationUser.Gender);
            return View(aplicationUser);
        }

        // GET: AplicationUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicationUser = await _context.Users.FindAsync(id);
            if (aplicationUser == null)
            {
                return NotFound();
            }
            ViewData["Gender"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", aplicationUser.Gender);
            return View(aplicationUser);
        }

        // POST: AplicationUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LastName,MLastName,Biography,Gender,ImageProfile,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AplicationUser aplicationUser)
        {
            if (id != aplicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aplicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplicationUserExists(aplicationUser.Id))
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
            ViewData["Gender"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", aplicationUser.Gender);
            return View(aplicationUser);
        }

        // GET: AplicationUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicationUser = await _context.Users
                .Include(a => a.GenderNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicationUser == null)
            {
                return NotFound();
            }

            return View(aplicationUser);
        }

        // POST: AplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aplicationUser = await _context.Users.FindAsync(id);
            if (aplicationUser != null)
            {
                _context.Users.Remove(aplicationUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AplicationUserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
