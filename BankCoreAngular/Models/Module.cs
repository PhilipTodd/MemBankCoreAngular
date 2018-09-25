using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Models
{
    public class Module : BaseTableEntity
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
