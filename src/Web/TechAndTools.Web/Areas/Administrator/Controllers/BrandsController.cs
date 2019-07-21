namespace TechAndTools.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TechAndTools.Web.Areas.Administrator.ViewModels.Brands;

    public class BrandsController : AdministratorController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandInputModel model)
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        [HttpGet]
        public IActionResult All()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}