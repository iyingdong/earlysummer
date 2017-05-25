using EarlySummer.Platform.Module;
using System.Web.Mvc;

namespace EarlySummer.BusinessModules.HomeModules.Controllers
{
    public class HomeController: ModuleController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
