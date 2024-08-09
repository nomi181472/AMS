using AttendanceServices.Services.ShiftAssignmentService.Models.Request;
using AttendanceServices.Services.ShiftAssignmentService.Models.Response;
using AttendanceServices.Services.ShiftManagementService.Models.Request;
using AttendanceServices.Services.ShiftManagementService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService
{
    public interface IShiftAssignmentService
    {
        Task<bool> AddShiftAssignment(RequestAssignShiftToWorkingProfile request, string userId, CancellationToken cancellationToken);

        Task<List<ResponseGetShiftWorkingProfileWithDetails>> ListWithDetails(CancellationToken cancellationToken);

        Task<ResponseGetShiftWorkingProfileWithDetails> SingleWithDetails(string shiftcode, CancellationToken cancellationToken);

        Task<List<ResponseGetShiftWorkingProfileUpdated>> UpdateShiftAssignment(RequestUpdateShiftWorkingProfile request, string userId, CancellationToken cancellationToken);

        Task<List<ResponseGetShiftWorkingProfileDeleted>> DeleteShiftAssignment(RequestDeleteShiftWorkingProfile request, string userId, CancellationToken cancellationToken);
    }
}
