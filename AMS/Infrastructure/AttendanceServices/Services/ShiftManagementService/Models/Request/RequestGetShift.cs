using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftManagementService.Models.Request
{
    public class RequestGetShift
    {
        public string Code { get; set; } = KConstantCommon.UseNA;
    }
}
