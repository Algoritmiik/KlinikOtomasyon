using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.ViewComponents
{
    public class LayoutAlertViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}