using AttendanceServices.Services.ShiftDeductionSchedulerManagement.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftDeductionSchedulerManagement
{
    public interface IShiftDeductionSchedulerService
    {
        Task<bool> ShiftDeductionAssign(RequestAssignShiftDeduction request, string userId, CancellationToken cancellationToken);
    }
}
