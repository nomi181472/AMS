using AttendanceServices.Services.ShiftDeductionSchedulerManagement.Models.Request;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftDeductionSchedulerManagement
{
    public static class CRTShiftDeductionScheduler
    {
        public static ShiftDeductionScheduler ToDomain(this RequestAssignShiftDeduction req)
        {
            return new ShiftDeductionScheduler()
            {
                Id = Guid.NewGuid().ToString(),
                ShiftId = req.ShiftId,
                DeductionId = req.DeductionId,
                WorkingProfileId = req.WorkingProfileId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
        }
    }
}
