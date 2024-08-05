using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.FiscalYearService.Models.Response
{
    public class FiscalYearResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
