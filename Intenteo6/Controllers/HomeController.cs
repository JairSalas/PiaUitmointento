using Intenteo6.Models;
using Intenteo6.Models.dbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Intenteo6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DriveDreamDbContext _context;

        public HomeController(ILogger<HomeController> logger, DriveDreamDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var carros = await _context.Carros
                .Include(c => c.IdmodeloNavigation)
                .Include(c => c.MarcaNavigation)
                .ToListAsync();

            return View(carros);
        }
        public IActionResult Ayuda()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
