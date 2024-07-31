using AttendanceServices.CommonModels.Responses;
using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.AllowanceService.Models.Response
{
    public class ResponseGetAllowanceWithDetails: CompleteTrackingFields
    {
        public string Description { get; set; }
        public string Type { get; set; } 
        public string Tag { get; set; } 
    }
}
