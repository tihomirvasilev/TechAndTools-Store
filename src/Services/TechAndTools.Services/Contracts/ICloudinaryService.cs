using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TechAndTools.Services.Contracts
{
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
