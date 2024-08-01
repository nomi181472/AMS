using AttendanceServices.Services.LeaveService.Models.Request;
using AttendanceServices.Services.LeaveService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.LeaveService
{
    public interface ILeaveService
    {
        Task<bool> AddLeave(RequestAddLeave request, string userId, CancellationToken cancellationToken);
        Task<List<ResponseGetLeaveWithDetails>> GetLeaves(CancellationToken cancellationToken);

        Task<ResponseGetLeaveWithDetails> GetLeave(string leaveId, CancellationToken cancellationToken);

        Task<ResponseGetLeaveWithDetails> UpdateLeave(RequestUpdateLeave request, string leaveId, string userId, CancellationToken cancellationToken);

        Task<bool> SoftDeleteLeave(string leaveId,string userId, CancellationToken cancellationToken);


    }
}
