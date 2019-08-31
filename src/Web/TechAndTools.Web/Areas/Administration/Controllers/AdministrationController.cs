using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Commons.Constants;
using TechAndTools.Web.Controllers;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdministrationController : BaseController
    { }
}