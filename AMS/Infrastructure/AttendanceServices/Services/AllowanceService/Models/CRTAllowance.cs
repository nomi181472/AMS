using AttendanceServices.Services.AllowanceService.Models.Request;
using AttendanceServices.Services.AllowanceService.Models.Response;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.AllowanceService.Models
{
    public static class CRTAllowance
    {
        public static Allowance ToDomain(this RequestAddAllowance request)
        {
            return new Allowance
            {
                Description = request.Description,
                Tag = request.Tag,
                Type = request.Type,
            };
        }
        public static ResponseGetAllowanceWithDetails ToResponseWithDetails(this Allowance models)
        {
            return new ResponseGetAllowanceWithDetails
            {
                Description = models.Description,
                Tag = models.Tag,
                Type = models.Type,
                CreatedBy=models.CreatedBy,
                CreatedDate=models.CreatedDate,
                IsActive=models.IsActive,
                IsArchived=models.IsArchived,
                UpdatedBy=models.UpdatedBy,
                UpdatedDate=models.UpdatedDate,
                
                
            };
        }
    }
}
