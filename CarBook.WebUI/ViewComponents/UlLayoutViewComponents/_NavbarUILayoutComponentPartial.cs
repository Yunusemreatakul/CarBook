using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UlLayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
