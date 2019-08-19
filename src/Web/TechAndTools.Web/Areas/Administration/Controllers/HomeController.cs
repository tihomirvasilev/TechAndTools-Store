using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Administration;
using TechAndTools.Web.ViewModels.Orders;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class HomeController : AdministrationController
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                UnprocessedОrdersViewModels = this.orderService.GetUnprocessedOrders()
                    .To<UnprocessedОrderViewModel>()
                    .OrderByDescending(x => x.OrderDate)
                    .ToList(),
                ProcessedОrdersViewModels = this.orderService.GetProcessedOrders()
                    .To<ProcessedОrderViewModel>()
                    .OrderByDescending(x => x.ShippingDate)
                    .ToList()
            };
            ;
            return View(viewModel);
        }
    }
}
