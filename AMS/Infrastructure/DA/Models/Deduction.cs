using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class Deduction : Base<string>
    {
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
