using System.Linq;
using AutoMapper;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Products
{
    public class ProductIndexViewModel : IMapFrom<ProductServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Rating { get; set; }

        public string ImageUrl { get; set; }

        public bool IsOutOfStock { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductServiceModel, ProductIndexViewModel>()
                .ForMember(destination => destination.ImageUrl,
                    ops => ops.MapFrom(origin => origin.Images.First().ImageUrl ?? string.Empty));
        }
    }
}
