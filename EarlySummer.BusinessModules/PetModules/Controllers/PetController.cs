using EarlySummer.BusinessModules.PetModules.Domains;
using EarlySummer.Platform.Module;
using System.Web.Mvc;

namespace EarlySummer.BusinessModules.PetModules.Controllers
{
    public class PetController: ModuleController
    {
        IPetService service = new PetService();
        public PetController()
        {

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
