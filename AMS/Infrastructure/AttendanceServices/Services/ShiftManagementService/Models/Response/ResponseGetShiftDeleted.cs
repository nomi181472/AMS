using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftManagementService.Models.Response
{
    public class ResponseGetShiftDeleted
    {
        public string Code { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int NumDays { get; set; }
        public TimeOnly? TimeIn { get; set; }
        public TimeOnly? TimeOut { get; set; }
    }
}
