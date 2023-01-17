using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.ViewComponents
{
    public class LayoutHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}