using AttendanceServices.CommonModels.Responses;
using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.LeaveService.Models.Response
{
    public class ResponseGetLeaveWithDetails : CompleteTrackingFields
    {
        public string Code { get; set; } = KConstantCommon.UseNA;
        public string Name { get; set; } = KConstantCommon.UseNA;
        public string Description { get; set; } = KConstantCommon.UseNA;
        public int? CompanyId { get; set; } 


    }
}
