using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Web.InputModels.Administration.Products;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class ProductsController : AdministrationController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ProductInputModel model)
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        public IActionResult Edit(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}
