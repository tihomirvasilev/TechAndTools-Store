using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public interface IImageService
    {
        Task<bool> CreateAsync(string imageUrl, int productId);
    }
}
