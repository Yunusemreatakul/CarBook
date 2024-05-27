using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UlLayoutViewComponents
{
    public class _MainCoverUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
