using Microsoft.AspNetCore.Mvc;
using TechAndTools.Web.Controllers;

namespace TechAndTools.Web.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
