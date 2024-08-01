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
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}
