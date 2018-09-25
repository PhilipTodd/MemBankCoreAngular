using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Models
{
    public class CodeItem : BaseTableEntity
    {
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int? ModuleId { get; set; }
        public Module Module { get; set; }

        public int? LanguageId { get; set; }
        public Language Language { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Text { get; set; }

    }
}
