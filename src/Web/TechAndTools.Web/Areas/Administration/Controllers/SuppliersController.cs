using Microsoft.AspNetCore.Mvc;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class SuppliersController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}