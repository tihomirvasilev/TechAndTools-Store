using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Commons.Constants;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUserService userService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly ISupplierService supplierService;
        private readonly IProductService productService;
        private readonly TechAndToolsDbContext context;

        public OrderService(IUserService userService,
            IShoppingCartService shoppingCartService,
            ISupplierService supplierService,
            IProductService productService,
            TechAndToolsDbContext context)
        {
            this.userService = userService;
            this.shoppingCartService = shoppingCartService;
            this.supplierService = supplierService;
            this.productService = productService;
            this.context = context;
        }

        public OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice)
        {
            var shoppingCartProducts = this.shoppingCartService
                .GetAllShoppingCartProducts(username)
                .ToList();

            if (shoppingCartProducts.Count == 0)
            {
                throw new ArgumentNullException(nameof(shoppingCartProducts));
            }

            var user = this.userService.GetUserByUsername(username);
            var supplier = this.supplierService.GetSupplierById(orderServiceModel.SupplierId);

            Order order = orderServiceModel.To<Order>();

            foreach (var shoppingCartProduct in shoppingCartProducts)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    Order = order,
                    ProductId = shoppingCartProduct.ProductId,
                    Price = shoppingCartProduct.Product.Price,
                    Quantity = shoppingCartProduct.Quantity
                });

                this.productService.DecreaseQuantityInStock(shoppingCartProduct.ProductId,
                    shoppingCartProduct.Quantity);
            }

            order.OrderProducts = shoppingCartProducts
                .Select(scp => new OrderProduct
                {
                    Order = order,
                    ProductId = scp.ProductId,
                    Price = scp.Product.Price,
                    Quantity = scp.Quantity
                })
                .ToList();

            this.shoppingCartService.RemoveAllProductFromShoppingCart(username);

            OrderStatus orderStatus = this.context.OrderStatuses.FirstOrDefault(x => x.Name == GlobalConstants.Unprocessed);
            PaymentStatus paymentStatus = this.context.PaymentStatuses.FirstOrDefault(x => x.Name == GlobalConstants.Unpaid);

            order.DeliveryPrice = deliveryPrice;
            order.OrderDate = DateTime.UtcNow;
            order.UserId = user.Id;
            order.OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
            order.PaymentStatus = paymentStatus ?? throw new ArgumentNullException(nameof(paymentStatus));
            order.TotalPrice = order.OrderProducts.Sum(product => product.Price * product.Quantity);
            order.ExpectedDeliveryDate = DateTime.UtcNow.AddDays(supplier.DeliveryTimeInDays);

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return order.To<OrderServiceModel>();
        }

        public OrderServiceModel GetOrderById(int orderId)
        {
            OrderServiceModel orderFromDb = this.context.Orders
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product.Images)
                .To<OrderServiceModel>()
                .SingleOrDefault(x => x.Id == orderId);

            if (orderFromDb == null)
            {
                throw new ArgumentNullException(nameof(orderFromDb));
            }

            return orderFromDb;
        }

        public async Task<bool> DeliverOrderAsync(int id)
        {
            OrderStatus statusProcess = this.context.OrderStatuses
                .FirstOrDefault(x => x.Name == GlobalConstants.Delivered);

            if (statusProcess == null)
            {
                throw new ArgumentNullException(nameof(statusProcess));
            }

            Order order = this.context.Orders
                .FirstOrDefault(x => x.Id == id && (x.OrderStatus.Name == GlobalConstants.Unprocessed
                                                    || x.OrderStatus.Name == GlobalConstants.Processed));

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            order.OrderStatusId = statusProcess.Id;
            order.DeliveryDate = DateTime.UtcNow;

            this.context.Orders.Update(order);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IEnumerable<OrderServiceModel> GetAllOrdersByUserId(string username)
        {
            IEnumerable<Order> ordersFromDb = this.context.Orders
                .Where(x => x.User.UserName == username)
                .Include(x => x.OrderStatus)
                .Include(x => x.PaymentMethod)
                .Include(x => x.PaymentStatus)
                .ToList();

            return ordersFromDb.Select(x => x.To<OrderServiceModel>()).ToList();
        }

        public IQueryable<OrderServiceModel> GetUnprocessedOrders()
        {
            return this.context.Orders
                .Where(x => x.OrderStatus.Name == GlobalConstants.Unprocessed)
                .To<OrderServiceModel>();
        }

        public IQueryable<OrderServiceModel> GetProcessedOrders()
        {
            return this.context.Orders
                .Where(x => x.OrderStatus.Name == GlobalConstants.Processed)
                .To<OrderServiceModel>();
        }
        public IQueryable<OrderServiceModel> GetDeliveredOrders()
        {
            return this.context.Orders
                .Where(x => x.OrderStatus.Name == GlobalConstants.Delivered)
                .To<OrderServiceModel>();
        }

        public async Task<bool> ProcessOrderAsync(int id)
        {
            OrderStatus statusProcess = this.context.OrderStatuses
                .FirstOrDefault(x => x.Name == GlobalConstants.Processed);

            if (statusProcess == null)
            {
                throw new ArgumentNullException(nameof(statusProcess));
            }

            Order order = this.context.Orders.
                FirstOrDefault(x => x.Id == id && (x.OrderStatus.Name == GlobalConstants.Unprocessed
                                                   || x.OrderStatus.Name == GlobalConstants.Delivered));

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            order.OrderStatusId = statusProcess.Id;
            order.ShippingDate = DateTime.UtcNow;

            this.context.Orders.Update(order);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
