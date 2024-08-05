using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.FiscalYearService.Models.Request
{
    public class CreateFiscalYearRequest
    {
        public string? Name { get; set; }
        public string? type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
