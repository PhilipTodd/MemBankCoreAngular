using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.Models
{
    public class TagCloudData
    {
        public string Text { get; set; }
        public int Weight { get; set; }
        public string Link { get; set; }
        public bool External { get; set; }
        public string Color { get; set; }
        public int Rotate { get; set; }
    }
}
