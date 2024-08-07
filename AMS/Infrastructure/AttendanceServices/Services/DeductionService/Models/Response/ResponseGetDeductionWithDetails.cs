using AttendanceServices.CommonModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.DeductionService.Models.Response
{
    public class ResponseGetDeductionWithDetails : CompleteTrackingFields
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
}
