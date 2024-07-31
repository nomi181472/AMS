using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class WorkingProfile : Base<string>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public virtual string FiscalYearId { get; set; }
        public int GraceTimeIn { get; set; }
        public int GraceTimeOut { get; set; }
        public int WorkingDays { get; set; }
        public int WorkingHours { get; set; }

        public ICollection<AllowanceWorkingProfileManagement> AllowanceWorkingProfileManagements { get; set; } 
        public ICollection<LeaveWorkingProfileManagement> LeaveWorkingProfileManagements { get;  set; }

        public  virtual FiscalYear FiscalYear { get; set; }  

    }
}
