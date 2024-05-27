using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UlLayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
