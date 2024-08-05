using AttendanceServices.Services.FiscalYearService.Models.Request;
using AttendanceServices.Services.FiscalYearService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.FiscalYearService
{
    public interface IFiscalYearService
    {
        Task<bool> AddFiscalYear(CreateFiscalYearRequest request, string userId, CancellationToken cancellationToken);
        Task<bool> UpdateFiscalYear(UpdateFiscalYearRequest request, string userId, CancellationToken cancellationToken);
        Task<bool> DeleteFiscalYearById(string Id, string UserId, CancellationToken cancellationToken);
        Task<List<FiscalYearResponse>> ListAllFiscalYears(string userId, CancellationToken cancellationToken);
    }
}
