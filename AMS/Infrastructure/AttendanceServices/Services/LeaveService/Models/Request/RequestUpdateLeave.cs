using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.LeaveService.Models.Request
{
    public class RequestUpdateLeave
    {
        public string Code { get; set; }
        public string Name { get; set; } = KConstantCommon.UseNA;
        public string Description { get; set; } = KConstantCommon.UseNA;
        public int? CompanyId { get; set; }
    }
}
