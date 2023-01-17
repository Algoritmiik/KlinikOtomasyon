using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.ViewComponents
{
    public class LayoutMainMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}