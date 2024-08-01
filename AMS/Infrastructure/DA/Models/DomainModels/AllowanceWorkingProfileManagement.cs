using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class AllowanceWorkingProfileManagement : Base<string>
    {
        public string AllownaceId { get; set; }
        public string WorkingProfileId { get; set; }

        public virtual Allowance Allowance { get; set; }

        public virtual WorkingProfile WorkingProfile { get; set; }

    }
}
