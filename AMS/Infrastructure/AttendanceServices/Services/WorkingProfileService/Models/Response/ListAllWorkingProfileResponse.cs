using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.WorkingProfileService.Models.Response
{
    public class WorkingProfileResponse
    {
        public virtual string? Id { get; set; }
        public virtual string? Code { get; set; }
        public virtual string? Description { get; set; }
        public virtual int? GraceTimeIn { get; set; }
        public virtual int? GraceTimeOut { get; set; }
        public virtual int? WorkingDays { get; set; }
        public virtual int? WorkingHours { get; set; }
        public virtual string? FiscalYearId { get; set; }
    }
}
