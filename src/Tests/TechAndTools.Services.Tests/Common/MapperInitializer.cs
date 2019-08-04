using System.Reflection;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Administration.Brands;
using TechAndTools.Web.ViewModels;
using TechAndTools.Web.ViewModels.Administration.Brands;

namespace TechAndTools.Services.Tests.Common
{
    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly,
               typeof(BrandIndexViewModel).GetTypeInfo().Assembly,
               typeof(BrandInputModel).GetTypeInfo().Assembly,
               typeof(BrandServiceModel).GetTypeInfo().Assembly);
        }
    }
}
