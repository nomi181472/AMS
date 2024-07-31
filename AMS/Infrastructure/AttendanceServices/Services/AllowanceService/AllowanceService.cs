using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.AllowanceService.Models;
using AttendanceServices.Services.AllowanceService.Models.Request;
using AttendanceServices.Services.AllowanceService.Models.Response;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.AllowanceService
{
    public class AllowanceService : IAllowanceService
    {
        IUnitOfWork _unit;
        public AllowanceService(IUnitOfWork unitOfWork)
        {
            _unit=unitOfWork;
        }
        public async Task<bool> AddAllowance(RequestAddAllowance request, string userId, CancellationToken cancellationToken)
        {
            var entity= request.ToDomain();
            entity.UpdatedBy = userId;
            entity.CreatedDate= DateTime.Now;
            entity.UpdatedDate= DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive=true;
            await _unit.allowanceRepo.AddAsync(entity, userId,cancellationToken);
            await _unit.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<List<ResponseGetAllowanceWithDetails>> ListWithDetails(CancellationToken cancellationToken)
        {
            var result=await _unit.allowanceRepo.GetAllAsync(cancellationToken);
            List<ResponseGetAllowanceWithDetails> response = new List<ResponseGetAllowanceWithDetails>();
            if (result.Status)
            {
                foreach (var record in result.Data)
                {
                    response.Add(record.ToResponseWithDetails());
                }
                return response;
            }
            else
            {
                throw new UnknownException(result.Message);
            }
            
        }
    }
}
