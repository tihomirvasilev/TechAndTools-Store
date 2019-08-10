using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class ImageService : IImageService
    {
        private readonly TechAndToolsDbContext context;

        public ImageService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(string imageUrl, int productId)
        {
            Image image = new Image
            {
                ImageUrl = imageUrl,
                ProductId = productId
            };

            await this.context.Images.AddAsync(image);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
