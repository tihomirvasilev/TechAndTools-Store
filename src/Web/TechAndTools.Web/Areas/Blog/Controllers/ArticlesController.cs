using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.Controllers;
using TechAndTools.Web.ViewModels.Articles;

namespace TechAndTools.Web.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class ArticlesController : BaseController
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IActionResult All()
        {
            IEnumerable<AllArticleViewModel> articleViewModels = this.articleService
                .GetAllArticles()
                .To<AllArticleViewModel>()
                .ToList();

            return this.View(articleViewModels);
        }

        public async Task<IActionResult> Details(int articleId)
        {
            DetailsArticleViewModel articleViewModel = (await this.articleService.GetArticleAsync(articleId))
                .To<DetailsArticleViewModel>();

            TempData["last-articles"] = this.articleService
                .GetLastThreeArticles(articleId)
                .To<AllArticleViewModel>()
                .ToList();

            return this.View(articleViewModel);
        }
    }
}
