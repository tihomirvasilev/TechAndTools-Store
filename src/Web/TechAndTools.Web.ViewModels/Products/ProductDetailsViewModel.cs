using System.Collections.Generic;
using AutoMapper;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.Images;

namespace TechAndTools.Web.ViewModels.Products
{
    public class ProductDetailsViewModel : IMapFrom<ProductServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ProductCategoryName { get; set; }

        public string BrandName { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public bool IsOutOfStock { get; set; }

        public ICollection<ImageServiceModel> Images { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ProductServiceModel, ProductDetailsViewModel>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
        }
    }
}
