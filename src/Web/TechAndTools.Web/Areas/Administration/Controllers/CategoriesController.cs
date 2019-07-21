using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Web.InputModels.Administration.Categories;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdministrationController
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