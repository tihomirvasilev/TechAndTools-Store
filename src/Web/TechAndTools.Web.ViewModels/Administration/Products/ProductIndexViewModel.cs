using AutoMapper;
using System.Linq;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.Products
{
    public class ProductIndexViewModel : IMapFrom<ProductServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductServiceModel, ProductIndexViewModel>()
                .ForMember(destination => destination.ImageUrl,
                    ops => ops.MapFrom(origin => origin.Images.First().ImageUrl ?? string.Empty));
        }
    }
}
