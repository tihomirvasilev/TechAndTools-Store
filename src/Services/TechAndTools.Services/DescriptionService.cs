using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public class DescriptionService : IDescriptionService
    {
        private readonly TechAndToolsDbContext context;

        public DescriptionService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<Description> CreateDescriptionAsync(int productId)
        {
            var description = new Description
            {
                ProductId = productId
            };

            await this.context.Descriptions.AddAsync(description);
            await this.context.SaveChangesAsync();

            return description;
        }

        public async Task<DescriptionProperty> CreateDescriptionPropertyAsync(int descriptionId, string name, string value)
        {
            var descriptionProperty = new DescriptionProperty
            {
                Name = name,
                Value = value,
                DescriptionId = descriptionId
            };

            await this.context.DescriptionProperties.AddAsync(descriptionProperty);
            await this.context.SaveChangesAsync();

            return descriptionProperty;
        }

        public IQueryable<DescriptionProperty> GetAllDescriptionPropertiesByDescriptionId(int descriptionId)
        {
            return this.context.DescriptionProperties
                .Where(descriptionProperty => descriptionProperty.DescriptionId == descriptionId);
        }

        public Description GetDescriptionById(int descriptionId)
        {
            return this.context.Descriptions.Find(descriptionId);
        }

        public Description GetDescriptionByProductId(int productId)
        {
            return this.context.Descriptions.FirstOrDefault(description => description.ProductId == productId);
        }
    }
}
