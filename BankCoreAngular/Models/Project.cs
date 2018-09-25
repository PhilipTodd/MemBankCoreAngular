using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Models
{
    public class Project : BaseTableEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
