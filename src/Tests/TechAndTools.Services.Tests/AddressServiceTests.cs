using Microsoft.EntityFrameworkCore;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using Xunit;
using Moq;

namespace TechAndTools.Services.Tests
{
    public class AddressServiceTests
    {
        [Fact]
        public void CreateShouldCreateAddress()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                        .UsedatabaseName: "Address_AddAddressToUser_Database")
                        .Options;

            var address = new DeliveryAddress
            {
                Country = "Bulgaria",
                City = "Varna",
                Address = "Vladislavovo",
                PostCode = 9023
            };


        }
    }
}
