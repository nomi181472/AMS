using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class Leave : Base<string>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public ICollection<LeaveWorkingProfileManagement> LeaveWorkingProfileManagements { get; set; }
    }
}
