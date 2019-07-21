using Microsoft.AspNetCore.Mvc;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
