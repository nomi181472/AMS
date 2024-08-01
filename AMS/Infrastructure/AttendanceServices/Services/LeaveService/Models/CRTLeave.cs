using AttendanceServices.Services.LeaveService.Models.Request;
using AttendanceServices.Services.LeaveService.Models.Response;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.LeaveService.Models
{
    public static class CRTLeave
    {
        public static Leave ToDomain(this RequestAddLeave request)
        {
            return new Leave
            {
                Code = request.Code,
                Description = request.Description,
                Name = request.Name,
                CompanyId = request.CompanyId,

            };
        }

        public static ResponseGetLeaveWithDetails ToResponseWithDetails(this Leave models)
        {
            return new ResponseGetLeaveWithDetails
            {
                Name = models.Name,
                Description = models.Description,
                Code = models.Code,
                CompanyId = models.CompanyId,
                CreatedBy = models.CreatedBy,
                CreatedDate = models.CreatedDate,
                IsActive = models.IsActive,
                IsArchived = models.IsArchived,
                UpdatedBy = models.UpdatedBy,
                UpdatedDate = models.UpdatedDate
            };
        }
       
    }
}
