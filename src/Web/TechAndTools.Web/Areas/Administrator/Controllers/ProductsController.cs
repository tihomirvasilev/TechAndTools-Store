namespace TechAndTools.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TechAndTools.Web.Areas.Administrator.ViewModels.Models;

    public class ProductsController : AdministratorController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInputModel model)
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}
