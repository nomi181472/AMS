using AttendanceServices.Services.AllowanceService.Models.Request;
using AttendanceServices.Services.AllowanceService.Models.Response;
using AttendanceServices.Services.ShiftManagementService.Models.Request;
using AttendanceServices.Services.ShiftManagementService.Models.Response;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftManagementService.Models
{
    public static class CRTShift
    {
        public static Shift ToDomain(this RequestAddShift request)
        {
            return new Shift
            {
                Id = Guid.NewGuid().ToString(),
                Code = request.Code,
                Description = request.Description,
                Status = request.Status,
                NumDays = request.NumDays,
                TimeIn = request.TimeIn,
                TimeOut = request.TimeOut
            };
        }

        public static ResponseGetShiftWithDetails ToResponseWithDetails(this Shift models)
        {
            return new ResponseGetShiftWithDetails
            {
                Code = models.Code,
                Description = models.Description,
                Status = models.Status,
                NumDays = models.NumDays,
                TimeIn = models.TimeIn,
                TimeOut =  models.TimeOut,

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
