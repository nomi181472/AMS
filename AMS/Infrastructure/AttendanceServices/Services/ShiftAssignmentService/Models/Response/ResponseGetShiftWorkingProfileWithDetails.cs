using AttendanceServices.CommonModels.Responses;
using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService.Models.Response
{
    public class ResponseGetShiftWorkingProfileWithDetails : CompleteTrackingFields
    {
        public virtual string? ShiftId { get; set; }
        public virtual string? WorkingProfileId { get; set; }
    }
}
