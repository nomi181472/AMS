using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class Allowance:Base<string>
    {
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Type { get; set; }
    }
}
