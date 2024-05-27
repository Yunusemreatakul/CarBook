using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UlLayoutViewComponents
{
    public class _FooterUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
