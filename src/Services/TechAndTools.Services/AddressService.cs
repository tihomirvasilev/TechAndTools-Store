using System;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;

namespace TechAndTools.Services
{
    public class AddressService : IAddressService
    {
        private readonly TechAndToolsDbContext context;
        private readonly IUserService userService;

        public AddressService(TechAndToolsDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public void Create(string country, string city, string address, int postCode)
        {
            var deliveryAddress = new DeliveryAddress
            {
                Country = country,
                City = city,
                Address = address,
                PostCode = postCode,
            };

            this.context.DeliveryAddresses.Add(deliveryAddress);
            this.context.SaveChanges();
        }

        public DeliveryAddress GetAddressByUserId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
