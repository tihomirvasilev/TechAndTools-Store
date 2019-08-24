using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.Images;

namespace TechAndTools.Web.ViewModels.Articles
{
    public class AllArticleViewModel : IMapFrom<ArticleServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public string ImgUrl { get; set; }

        public int TimesRead { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorId { get; set; }
        public TechAndToolsUser Author { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ArticleServiceModel, AllArticleViewModel>()
                .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.Images.FirstOrDefault().ImageUrl));
        }
    }
}
