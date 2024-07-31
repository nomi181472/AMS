using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class Deduction : Base<string>
    {
        
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
