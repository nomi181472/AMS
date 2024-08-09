using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService.Request
{
    public class RequestAddShiftWorkingProfile
    {
        public virtual string? ShiftId { get; set; } = KConstantCommon.UseNA;
        public virtual string? WorkingProfileId { get; set; } = KConstantCommon.UseNA;
    }
}
