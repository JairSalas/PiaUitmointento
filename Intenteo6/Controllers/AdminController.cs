using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intenteo6.Controllers
{
    [Authorize(Roles = "Admin")]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class AdminController : Controller
    {
        public IActionResult AgregarPostNoticias2()
        {
            return View();
        }

        public IActionResult AgregarPostNoticia()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult Reportes()
        {
            return View();
        }

        public IActionResult VerInventario()
        {
            return View();
        }

        public IActionResult Caja()
        {
            return View();
        }

        public IActionResult AgregarPostCarro()
        {
            return View();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
