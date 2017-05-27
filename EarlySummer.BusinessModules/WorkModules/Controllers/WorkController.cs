using EarlySummer.BusinessModules.DataAccess.Entity;
using EarlySummer.BusinessModules.WorkModules.Domains;
using EarlySummer.Platform.Module;
using System;
using System.Web.Mvc;

namespace EarlySummer.BusinessModules.WorkModules.Controllers
{
    public class WorkController: ModuleController
    {
        IWorkService service;
        public WorkController(IWorkService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var list = service.GetList();
            return View(list);
        }

        public ActionResult Edit(Guid? Id)
        {
            var model = new Work();
            if (Id.HasValue)
            {
                model = service.GetModelById(Id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Work model)
        {
            var result = service.Update(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Count(Guid Id)
        {
            string result = service.Count(Id);
            return Json(result);
        }
    }
}
