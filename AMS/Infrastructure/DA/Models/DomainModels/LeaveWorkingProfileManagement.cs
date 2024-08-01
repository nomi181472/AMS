using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class LeaveWorkingProfileManagement : Base<string>
    {
        public string LeaveId { get; set; }
        public string WorkingProfileId { get; set; }

        public virtual Leave Leave { get; set; }
        public virtual WorkingProfile WorkingProfile { get; set; }

    }
}
