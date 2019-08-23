using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Services.Contracts;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class OrdersController : AdministrationController
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Details(int id)
        {
            //TODO: Implement
            return this.View();
        }

        public IActionResult Processed()
        {
            //TODO: Implement
            return this.View();
        }
        public IActionResult Unprocessed()
        {
            //TODO: Implement
            return this.View();
        }

        public async Task<IActionResult> Process(int id)
        {
            await this.orderService.ProcessOrder(id);

            return this.Redirect("/Administration/Home/Index");
        }

        public async Task<IActionResult> Deliver(int id)
        {
            await this.orderService.DeliverOrder(id);

            return this.Redirect("/Administration/Home/Index");
        }

        public IActionResult Cancel(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}
