using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Models
{
    public class BaseTableEntity
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 100)]
        public DateTime? Created { get; set; }
        [Column(Order = 101)]
        public DateTime? Modified { get; set; }
    }
}
