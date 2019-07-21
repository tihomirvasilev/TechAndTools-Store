namespace TechAndTools.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TechAndTools.Web.Areas.Administrator.ViewModels.Categories;

    public class CategoriesController : AdministratorController
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryInputModel model)
        {
            //TODO: Implement
            return this.Redirect("/");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        public IActionResult All()
        {
            //TODO: Implement
            return this.View();
        }

        public IActionResult Delete(int id)
        {
            //TODO: Implement
            return Redirect("All");
        }
    }
}