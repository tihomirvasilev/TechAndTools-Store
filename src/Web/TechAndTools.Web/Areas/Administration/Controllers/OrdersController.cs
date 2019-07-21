using Microsoft.AspNetCore.Mvc;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class OrdersController : AdministrationController
    {
        public IActionResult Details(int id)
        {
            //TODO: Implement
            return this.View();
        }

        public IActionResult Pending()
        {
            //TODO: Implement
            return this.View();
        }

        public IActionResult Process(int id)
        {
            //TODO: Implement
            return this.Redirect("Process");
        }

        public IActionResult Deliver(int id)
        {
            //TODO: Implement
            return this.Redirect("Deliver");
        }

        public IActionResult Cancel(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}
