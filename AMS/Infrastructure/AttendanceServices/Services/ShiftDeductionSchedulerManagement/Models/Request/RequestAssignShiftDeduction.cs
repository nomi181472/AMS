using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftDeductionSchedulerManagement.Models.Request
{
    public class RequestAssignShiftDeduction
    {
        public string ShiftId { get; set; }
        public string DeductionId { get; set; }
        public string WorkingProfileId { get; set; }
    }
}
