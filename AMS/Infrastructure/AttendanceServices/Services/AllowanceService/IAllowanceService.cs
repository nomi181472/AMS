using AttendanceServices.Services.AllowanceService.Models.Request;
using AttendanceServices.Services.AllowanceService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.AllowanceService
{
    public interface IAllowanceService
    {
        Task<bool> AddAllowance(RequestAddAllowance request, string userId, CancellationToken cancellationToken);
        Task<List<ResponseGetAllowanceWithDetails>> ListWithDetails(CancellationToken cancellationToken);
    }
}
