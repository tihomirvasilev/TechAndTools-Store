using System;
using System.Linq;
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

        public async Task<bool> CreateWithProductAsync(string imageUrl, int productId)
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

        public async Task<bool> CreateWithArticleAsync(string imageUrl, int articleId)
        {
            Image image = new Image
            {
                ImageUrl = imageUrl,
                ArticleId = articleId
            };

            await this.context.Images.AddAsync(image);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<ImageServiceModel> EditWithArticleAsync(string imageUrl, int articleId)
        {
            Image imageFromDb = this.context.Images.SingleOrDefault(x => x.ArticleId == articleId);

            if (imageFromDb == null)
            {
                throw new ArgumentNullException("Image is null!");
            }

            imageFromDb.ImageUrl = imageUrl;

            this.context.Images.Update(imageFromDb);
            await this.context.SaveChangesAsync();

            return imageFromDb.To<ImageServiceModel>();
        }
    }
}
