using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAndTools.Web.Areas.Administrator.Controllers
{
    public class HomeController : AdministratorController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
