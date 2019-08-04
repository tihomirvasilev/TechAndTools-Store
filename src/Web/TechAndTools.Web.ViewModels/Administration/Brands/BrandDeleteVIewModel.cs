using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.Brands
{
    public class BrandDeleteVIewModel : IMapFrom<BrandServiceModel>, IMapTo<BrandServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string OfficialSite { get; set; }
    }
}
