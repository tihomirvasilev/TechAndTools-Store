using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IArticleService
    {
        
        IQueryable<ArticleServiceModel> GetAllArticles();

        IQueryable<ArticleServiceModel> GetAllByUserIdAsync(string userId);

        IQueryable<ArticleServiceModel> GetLastThreeArticles(int articleId);

        Task<ArticleServiceModel> CreateArticleAsync(ArticleServiceModel articleServiceModel, string authorId);

        Task<ArticleServiceModel> GetArticleByIdAsync(int articleId);

        Task<bool> DeleteArticleByIdAsync(int articleId);

        Task<ArticleServiceModel> GetArticleAsync(int articleId);
    }
}
