using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Models
{
    public class Language : BaseTableEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
