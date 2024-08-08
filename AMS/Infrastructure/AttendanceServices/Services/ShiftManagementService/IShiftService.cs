using AttendanceServices.Services.AllowanceService.Models.Request;
using AttendanceServices.Services.AllowanceService.Models.Response;
using AttendanceServices.Services.ShiftManagementService.Models.Request;
using AttendanceServices.Services.ShiftManagementService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftManagementService
{
    public interface IShiftService
    {
        Task<bool> AddShift(RequestAddShift request, string userId, CancellationToken cancellationToken);

        Task<List<ResponseGetShiftWithDetails>> ListWithDetails(CancellationToken cancellationToken);

        Task<ResponseGetShiftWithDetails> SingleWithDetails(string code, CancellationToken cancellationToken);

        Task<List<ResponseGetShiftUpdated>> UpdateShift(RequestUpdateShift request, string userId, CancellationToken cancellationToken);

        Task<List<ResponseGetShiftDeleted>> DeleteShift(RequestDeleteShift request, string userId, CancellationToken cancellationToken);
    }
}
