using EarlySummer.BusinessModules.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlySummer.BusinessModules.WorkModules.Domains
{
    public class WorkService : IWorkService
    {
        EarlySummerContext db = new EarlySummerContext();
        public List<Work> GetList()
        {
            var result = db.WorkEntities.ToList();

            return result;
        }



        public Work GetModelById(Guid Id)
        {
            var model = db.WorkEntities.Where(o => o.Id == Id).FirstOrDefault();
            return model;
        }

        public bool Update(Work model)
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
                model.CreationTime = DateTime.Now;
                db.WorkEntities.Add(model);
            }
            else
            {
                var entry = db.Entry(model);
                entry.State = EntityState.Modified;
            }
            return db.SaveChanges() > 0;
        }

        public string Count()
        {
            var message = "";

            return message;
        }
    }
}
