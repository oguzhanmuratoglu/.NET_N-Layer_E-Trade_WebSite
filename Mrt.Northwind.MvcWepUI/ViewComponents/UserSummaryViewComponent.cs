using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Mrt.Northwind.MvcWepUI.Models;

namespace Mrt.Northwind.MvcWepUI.ViewComponents
{
    public class UserSummaryViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            var userName = HttpContext.User.Identity.Name;

            UserDetailsViewModel model = new UserDetailsViewModel
            {
                UserName = userName
            };

            return View(model);
        }
    }
}
