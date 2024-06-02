using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intenteo6.Models.dbModels
{
    public class PostController : Controller
    {
        private readonly DriveDreamDbContext _context;
        
        public PostController(DriveDreamDbContext context)
        {
            _context= context;
        }
       
        //Get Posts
        public async Task<IActionResult> Index()
        {
            var carros = await _context.Carros.ToListAsync();
            return View(carros);
        }
        
    }
}
