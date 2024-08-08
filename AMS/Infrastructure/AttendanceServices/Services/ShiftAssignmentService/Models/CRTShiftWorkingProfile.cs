using AttendanceServices.Services.ShiftAssignmentService.Models.Request;
using AttendanceServices.Services.ShiftAssignmentService.Models.Response;
using AttendanceServices.Services.ShiftManagementService.Models.Request;
using AttendanceServices.Services.ShiftManagementService.Models.Response;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService.Models
{
    public static class CRTShiftWorkingProfile
    {
        public static ShiftWorkingProfile ToDomain(this RequestAddShiftWorkingProfile request)
        {
            return new ShiftWorkingProfile
            {
                Id = Guid.NewGuid().ToString(),
                ShiftId = request.ShiftId,
                WorkingProfileId = request.WorkingProfileId
            };
        }

        public static ResponseGetShiftWorkingProfileWithDetails ToResponseWithDetails(this ShiftWorkingProfile models)
        {
            return new ResponseGetShiftWorkingProfileWithDetails
            {
                ShiftId = models.ShiftId,
                WorkingProfileId = models.WorkingProfileId,

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
