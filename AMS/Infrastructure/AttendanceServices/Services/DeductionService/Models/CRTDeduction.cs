using AttendanceServices.Services.DeductionService.Models.Request;
using AttendanceServices.Services.DeductionService.Models.Response;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.DeductionService.Models
{
    public static class CRTDeduction
    {

        public static Deduction ToDomain(RequestAddDeduction request)
        {
            return new Deduction
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
            };
        }

        public static ResponseGetDeductionWithDetails ToResponseWithDetails(Deduction request)
        {
            return new ResponseGetDeductionWithDetails
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                CreatedBy = request.CreatedBy,
                CreatedDate = request.CreatedDate,
                IsActive = request.IsActive,
                IsArchived = request.IsArchived,
                UpdatedBy = request.UpdatedBy,
                UpdatedDate = request.UpdatedDate
            };
        }
    }
}
