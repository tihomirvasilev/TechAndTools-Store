namespace TechAndTools.Services.Contracts
{
    using System.Threading.Tasks;
    using TechAndTools.Data.Models;

    public interface IAddressService
    {
        void Create(string country, string city, string address, int postCode);

        DeliveryAddress GetAddressByUserId(string id);
    }
}
