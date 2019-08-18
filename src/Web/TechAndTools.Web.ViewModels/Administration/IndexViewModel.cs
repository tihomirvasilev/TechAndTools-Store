using System.Collections.Generic;
using TechAndTools.Web.ViewModels.Orders;

namespace TechAndTools.Web.ViewModels.Administration
{
    public class IndexViewModel
    {
        public IList<ProcessedОrderViewModel> ProcessedОrdersViewModels { get; set; } = new List<ProcessedОrderViewModel>();

        public IList<UnprocessedОrderViewModel> UnprocessedОrdersViewModels { get; set; } = new List<UnprocessedОrderViewModel>();
    }
}
