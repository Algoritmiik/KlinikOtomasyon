using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.Controllers
{
    [Authorize(Roles = "Nurse")]
    public class NursesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }
    }
}