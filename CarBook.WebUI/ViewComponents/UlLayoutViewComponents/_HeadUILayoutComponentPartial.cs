using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UlLayoutViewComponents
{
    public class _HeadUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
