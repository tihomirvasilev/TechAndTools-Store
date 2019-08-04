using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Web.InputModels.Administration.Products;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class ProductsController : AdministrationController
    {
        [HttpGet]
        public async Task<IActionResult> Create()
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
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        public async Task<IActionResult> Delete()
        {
            //TODO: Implement
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }
    }
}
