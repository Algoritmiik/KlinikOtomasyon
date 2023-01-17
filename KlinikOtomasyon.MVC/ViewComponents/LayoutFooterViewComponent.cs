using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.ViewComponents
{
    public class LayoutFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}