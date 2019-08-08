using System.Reflection;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Administration.Brands;
using TechAndTools.Web.ViewModels;
using TechAndTools.Web.ViewModels.Brands;

namespace TechAndTools.Services.Tests.Common
{
    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(typeof(BrandIndexViewModel).GetTypeInfo().Assembly,
               typeof(BrandCreateInputModel).GetTypeInfo().Assembly,
               typeof(BrandServiceModel).GetTypeInfo().Assembly,
               typeof(Brand).GetTypeInfo().Assembly);
        }
    }
}
