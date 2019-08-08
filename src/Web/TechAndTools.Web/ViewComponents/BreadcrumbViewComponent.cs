using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechAndTools.Web.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        //TODO: Implement

        public IViewComponentResult Invoke()
        {
            return this.View();
        }
    }
}
