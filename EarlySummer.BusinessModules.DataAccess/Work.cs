using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlySummer.BusinessModules.DataAccess
{
    public class Work
    {
        public Guid Id { get; set; }

        [Display(Name = "周一时间")]
        public DateTime MondayTime { get; set; }

        [Display(Name = "下班时间")]
        public string Content { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
