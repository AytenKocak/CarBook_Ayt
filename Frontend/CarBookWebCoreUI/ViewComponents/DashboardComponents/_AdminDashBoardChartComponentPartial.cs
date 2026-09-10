using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.DashboardComponents
{
    public class _AdminDashBoardChartComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
