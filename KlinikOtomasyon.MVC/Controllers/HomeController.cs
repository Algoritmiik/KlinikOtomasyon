using KlinikOtomasyon.MVC.Models.ResultModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        return await Task.Run(() => View(new HomeIndexResultModel()));
    }

    public async Task<IActionResult> Error()
    {
        return await Task.Run(() => View());
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
