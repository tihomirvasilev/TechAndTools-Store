using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Orders;

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
            DetailsOrderViewModel viewModel = this.orderService.GetOrderById(id).To<DetailsOrderViewModel>();

            return this.View(viewModel);
        }

        public IActionResult Processed()
        {
            IEnumerable<ProcessedОrderViewModel> viewModels = this.orderService
                .GetProcessedOrders()
                .To<ProcessedОrderViewModel>()
                .ToList();

            return this.View(viewModels);
        }

        public IActionResult Unprocessed()
        {
            IEnumerable<UnprocessedОrderViewModel> viewModels = this.orderService
                .GetUnprocessedOrders()
                .To<UnprocessedОrderViewModel>()
                .ToList();

            return this.View(viewModels);
        }
        public IActionResult Delivered()
        {
            IEnumerable<DeliveredOrderViewModel> viewModels = this.orderService
                .GetDeliveredOrders()
                .To<DeliveredOrderViewModel>()
                .ToList();

            return this.View(viewModels);
        }

        public async Task<IActionResult> Process(int id)
        {
            await this.orderService.ProcessOrderAsync(id);

            return this.Redirect("/Administration/Home/Index");
        }

        public async Task<IActionResult> Deliver(int id)
        {
            await this.orderService.DeliverOrderAsync(id);

            return this.Redirect("/Administration/Home/Index");
        }

    }
}
