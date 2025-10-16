using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverwievPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
