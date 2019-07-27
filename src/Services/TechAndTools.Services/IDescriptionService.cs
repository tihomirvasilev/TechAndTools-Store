using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface IDescriptionService
    {
        Task<Description> CreateDescriptionAsync(int productId);
        Task<DescriptionProperty> CreateDescriptionPropertyAsync(int descriptionId, string name, string value);
        IQueryable<DescriptionProperty> GetAllDescriptionPropertiesByDescriptionId(int descriptionId);
        Description GetDescriptionById(int descriptionId);
        Description GetDescriptionByProductId(int productId);
    }
}
