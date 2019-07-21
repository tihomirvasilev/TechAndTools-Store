using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechAndTools.Web.Areas.Administrator.Controllers
{
    public class SuppliersController : AdministratorController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}