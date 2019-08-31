using TechAndTools.Web.ViewModels.Products;
using X.PagedList;

namespace TechAndTools.Web.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public IPagedList<ProductIndexViewModel> ProductsViewModels { get; set; }

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }

        public int? CategoryId { get; set; }
    }
}
