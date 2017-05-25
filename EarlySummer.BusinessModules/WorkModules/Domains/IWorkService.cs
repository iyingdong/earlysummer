using EarlySummer.BusinessModules.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlySummer.BusinessModules.WorkModules.Domains
{
    public interface IWorkService
    {
        List<Work> GetList();

        Work GetModelById(Guid Id);

        bool Update(Work model);

        string Count();
    }
}
