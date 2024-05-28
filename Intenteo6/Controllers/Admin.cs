using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intenteo6.Controllers
{
    [Authorize(Roles="Admin")]
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
