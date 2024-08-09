using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService.Models.Request
{
    public class RequestAssignShiftToWorkingProfile
    {
        public virtual string? ShiftCode { get; set; } = KConstantCommon.UseNA;
        public virtual string? WorkingProfileCode { get; set; } = KConstantCommon.UseNA;
    }
}
