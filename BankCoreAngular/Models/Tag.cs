using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Models
{
    public class Tag : BaseTableEntity
    {
        [Required]
        public int ParentTypeId { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Text { get; set; }
    }
}
