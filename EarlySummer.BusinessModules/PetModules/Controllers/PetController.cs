using EarlySummer.BusinessModules.PetModules.Domains;
using EarlySummer.Platform.Module;
using System.Web.Mvc;

namespace EarlySummer.BusinessModules.PetModules.Controllers
{
    public class PetController: ModuleController
    {
        IPetService service;
        public PetController(IPetService service)
        {
            this.service = service;
        }


        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id)) {
                id = "8";
            }
            var model = service.GetPetList(id);
            return View(model);
        }
    }
}
