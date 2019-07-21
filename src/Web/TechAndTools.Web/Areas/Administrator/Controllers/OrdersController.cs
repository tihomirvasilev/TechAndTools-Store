namespace TechAndTools.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : AdministratorController
    {
        public IActionResult Details(int id)
        {
            //TODO: Implement
            return this.View();
        }

        public IActionResult Pendings()
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
