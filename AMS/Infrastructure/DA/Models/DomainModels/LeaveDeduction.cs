using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class LeaveDeduction : Base<string>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


    }
}
