using AttendanceServices.Services.ShiftAssignmentService.Request;
using AttendanceServices.Services.ShiftAssignmentService.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService
{
    public class ShiftAssignmentService : IShiftAssignmentService
    {
        public Task<bool> AddShiftAssignment(RequestAddShiftWorkingProfile request, string userId, CancellationToken cancellationToken)
        {


            return null;
        }

        public Task<List<ResponseGetShiftWorkingProfileWithDetails>> ListWithDetails(CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<ResponseGetShiftWorkingProfileWithDetails> SingleWithDetails(string shiftcode, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<List<ResponseGetShiftWorkingProfileUpdated>> UpdateShiftAssignment(RequestUpdateShiftWorkingProfile request, string userId, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<List<ResponseGetShiftWorkingProfileDeleted>> DeleteShiftAssignment(RequestDeleteShiftWorkingProfile request, string userId, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
