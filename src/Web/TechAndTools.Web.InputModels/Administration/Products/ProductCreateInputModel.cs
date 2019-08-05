using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Administration.Products
{
    public class ProductCreateInputModel : IMapTo<ProductServiceModel>, IMapFrom<ProductServiceModel>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public string Description { get; set; }

        public string DocumentationUrl { get; set; }

        [Required]
        public int Warranty { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int QuantityInStock { get; set; }

        [Required]
        public IFormFile ImageFormFile { get; set; }
    }
}
