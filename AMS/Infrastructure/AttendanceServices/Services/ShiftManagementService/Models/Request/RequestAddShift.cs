using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftManagementService.Models.Request
{
    public class RequestAddShift
    {
        public string Code { get; set; } = KConstantCommon.UseNA;

        public string Description { get; set; } = KConstantCommon.UseNA;

        public string Status { get; set; } = KConstantCommon.UseNA;

        public int NumDays { get; set; } = 0;

        public TimeOnly TimeIn = TimeOnly.MinValue;

        public TimeOnly TimeOut = TimeOnly.MinValue;
    }
}
