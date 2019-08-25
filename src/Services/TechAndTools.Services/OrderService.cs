using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.Orders;

namespace TechAndTools.Services
{
    public class OrderService : IOrderService
    {

        private readonly IUserService userService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly ISupplierService supplierService;
        private readonly TechAndToolsDbContext context;

        public OrderService(IUserService userService,
            IShoppingCartService shoppingCartService,
            ISupplierService supplierService,
            TechAndToolsDbContext context)
        {
            this.userService = userService;
            this.shoppingCartService = shoppingCartService;
            this.supplierService = supplierService;
            this.context = context;
        }

        public OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice)
        {
            var shoppingCartProducts = this.shoppingCartService
                .GetAllShoppingCartProducts(username)
                .ToList();

            if (shoppingCartProducts.Count == 0)
            {
                throw new ArgumentNullException("The cart is empty.");
            }

            var user = this.userService.GetUserByUsername(username);
            var supplier = this.supplierService.GetSupplierById(orderServiceModel.SupplierId);

            Order order = orderServiceModel.To<Order>();

            order.OrderProducts = shoppingCartProducts
                .Select(scp => new OrderProduct
                {
                    Order = order,
                    ProductId = scp.ProductId,
                    Price = scp.Product.Price,
                    Quantity = scp.Quantity
                })
                .ToList();

            this.shoppingCartService.DeleteAllProductFromShoppingCart(username);

            order.DeliveryPrice = deliveryPrice;
            order.OrderDate = DateTime.UtcNow;
            order.UserId = user.Id;
            order.OrderStatus = this.context.OrderStatuses.FirstOrDefault(x => x.Name == "Unprocessed");
            order.PaymentStatus = this.context.PaymentStatuses.FirstOrDefault(x => x.Name == "Unpaid");
            order.TotalPrice = order.OrderProducts.Sum(product => product.Price * product.Quantity);
            order.ExpectedDeliveryDate = DateTime.UtcNow.AddDays(supplier.DeliveryTimeInDays);

            this.context.Orders.Add(order);
            this.context.SaveChanges();
            
            return order.To<OrderServiceModel>();
        }

        public OrderServiceModel GetOrderById(int orderId)
        {
            OrderServiceModel orderServiceModel = this.context.Orders
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product.Images)
                .To<OrderServiceModel>()
                .SingleOrDefault(x => x.Id == orderId);
            
            if (orderServiceModel == null)
            {
                throw new ArgumentNullException("The Order not found!");
            }

            return orderServiceModel;
        }

        public async Task<bool> DeliverOrderAsync(int id)
        {
            var statusProcess = this.context.OrderStatuses.FirstOrDefault(x => x.Name == "Delivered");

            var order = this.context.Orders.FirstOrDefault(x => x.Id == id && 
                                                                (x.OrderStatus.Name == "Unprocessed" || x.OrderStatus.Name == "Processed"));
            if (order == null)
            {
                return false;
            }

            order.OrderStatusId = statusProcess.Id;
            order.DeliveryDate = DateTime.UtcNow;

            this.context.Orders.Update(order);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IEnumerable<OrderServiceModel> GetAllOrdersByUserId(string username)
        {
            var ordersFromDb = this.context.Orders
                .Where(x => x.User.UserName == username)
                .Include(x => x.OrderStatus)
                .Include(x => x.PaymentMethod)
                .Include(x => x.PaymentStatus)
                .ToList();
            ;
            return ordersFromDb.Select(x => x.To<OrderServiceModel>()).ToList();
        }

        public IQueryable<OrderServiceModel> GetUnprocessedOrders()
        {
            return this.context.Orders
                .Where(x => x.OrderStatus.Name == "Unprocessed")
                .To<OrderServiceModel>();
        }
        
        public IQueryable<OrderServiceModel> GetProcessedOrders()
        {
            return this.context.Orders
                .Where(x => x.OrderStatus.Name == "Processed")
                .To<OrderServiceModel>();
        }
        public IQueryable<OrderServiceModel> GetDeliveredOrders()
        {
            return this.context.Orders
                .Where(x => x.OrderStatus.Name == "Delivered")
                .To<OrderServiceModel>();
        }

        public async Task<bool> ProcessOrderAsync(int id)
        {
            var statusProcess = this.context.OrderStatuses.FirstOrDefault(x => x.Name == "Processed");

            var order = this.context.Orders.FirstOrDefault(x => x.Id == id && 
                                                           (x.OrderStatus.Name == "Unprocessed" || x.OrderStatus.Name == "Delivered"));
            if (order == null)
            {
                return false;
            }

            order.OrderStatusId = statusProcess.Id;
            order.ShippingDate = DateTime.UtcNow;

            this.context.Orders.Update(order);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
