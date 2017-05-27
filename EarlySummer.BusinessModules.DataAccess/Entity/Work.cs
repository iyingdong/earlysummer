using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlySummer.BusinessModules.DataAccess.Entity
{
    public class Work
    {
        [Key]
        public Guid WorkId { get; set; }

        [Display(Name ="名称")]
        [StringLength(20)]
        public string WorkName { get; set; }

        [Display(Name = "内容")]
        public string Content { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
