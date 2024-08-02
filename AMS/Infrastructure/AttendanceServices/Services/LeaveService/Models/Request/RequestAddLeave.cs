using AttendanceServices.EnumsAndConstants.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.LeaveService.Models.Request
{
    public class RequestAddLeave
    {
        [Required]
        public string Code { get; set; } 
        [Required]
        public string Name { get; set; } 
        [Required]
        public string Description { get; set; } 
        [Required]
        public int? CompanyId { get; set; }
    }
}
