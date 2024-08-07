using AttendanceServices.Services.DeductionService.Models.Request;
using AttendanceServices.Services.DeductionService.Models.Response;
using AttendanceServices.Services.LeaveService.Models.Request;
using AttendanceServices.Services.LeaveService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.DeductionService
{
    public interface IDeductionService
    {
        Task<bool> AddDeduction(RequestAddDeduction request, string userId, CancellationToken cancellationToken);
        Task<List<ResponseGetDeductionWithDetails>> GetDeductions(CancellationToken cancellationToken);

        Task<ResponseGetDeductionWithDetails> GetDeductionById(string deductionId, CancellationToken cancellationToken);
        Task<ResponseGetDeductionWithDetails> GetDeductionByCode(string deductionCode, CancellationToken cancellationToken);

        Task<ResponseGetDeductionWithDetails> UpdateDeduction(RequestUpdateDeduction request, string deductionCode, string userId, CancellationToken cancellationToken);

        Task<bool> SoftDeleteDeduction(string deductionCode, string userId, CancellationToken cancellationToken);
    }
}
