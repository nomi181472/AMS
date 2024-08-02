using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.LeaveService.Models;
using AttendanceServices.Services.LeaveService.Models.Request;
using AttendanceServices.Services.LeaveService.Models.Response;
using DA;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.LeaveService
{
    public class LeaveService : ILeaveService
    {
        IUnitOfWork _unit;

        public LeaveService(IUnitOfWork unit)
        { 
            _unit = unit; 
        }
        public async Task<bool> AddLeave(RequestAddLeave request, string userId, CancellationToken cancellationToken)
        {
            var entity = CRTLeave.ToDomain(request);
            entity.UpdatedBy = userId;
            entity.CreatedBy = userId;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive = true;
            await _unit.leaveRepo.AddAsync(entity,userId,cancellationToken);
            await _unit.CommitAsync(cancellationToken);
            return true;

        }

        public async Task<ResponseGetLeaveWithDetails> GetLeave(string leaveId, CancellationToken cancellationToken)
        {
            var result = await _unit.leaveRepo.GetByIdAsync(leaveId,cancellationToken);
            ResponseGetLeaveWithDetails response;
            if(result.Status && result.Data != null)
            {
                response =  CRTLeave.ToResponseWithDetails(result.Data);
                return response;
            }
            else
            {
                throw new UnknownException(result.Message);
            }
        }

        public async Task<List<ResponseGetLeaveWithDetails>> GetLeaves(CancellationToken cancellationToken)
        {
            var result = await _unit.leaveRepo.GetAllAsync(cancellationToken);
            List<ResponseGetLeaveWithDetails> response = new List<ResponseGetLeaveWithDetails>();
            if (result.Status && result.Data != null)
            {
                foreach (var record in result.Data)
                {
                    response.Add(CRTLeave.ToResponseWithDetails(record));
                }
                return response;
            }
            else
            {
                throw new UnknownException(result.Message);
            }
        }

        public async Task<bool> SoftDeleteLeave(string leaveId, string userId, CancellationToken cancellationToken)
        {
            var result = await _unit.leaveRepo.GetByIdAsync(leaveId, cancellationToken);

            if (result.Status )
            {
                if (result.Data != null)
                {
                    var leave = result.Data;
                    leave.IsActive = false;
                    leave.IsArchived = true;
                    leave.UpdatedBy = userId;
                    leave.UpdatedDate = DateTime.Now;

                    await _unit.leaveRepo.UpdateAsync(leave, userId, cancellationToken);
                    await _unit.CommitAsync(cancellationToken);
                    return true;
                }else
                {
                    throw new RecordNotFoundException("leave Id not found.");
                }
            }
            else
            {
                throw new UnknownException(result.Message) ;
            }
        }

        public async Task<ResponseGetLeaveWithDetails> UpdateLeave(RequestUpdateLeave request, string leaveId, string userId, CancellationToken cancellationToken)
        {
            var result = await _unit.leaveRepo.GetByIdAsync(leaveId, cancellationToken);

            if (result.Status && result.Data != null)
            {
                var leave = result.Data;
                leave.Code = request.Code;
                leave.Name = request.Name;
                leave.Description = request.Description;
                leave.CompanyId = request.CompanyId;
                leave.UpdatedBy = userId;
                leave.UpdatedDate = DateTime.Now;
                
                await _unit.leaveRepo.UpdateAsync(leave, userId, cancellationToken);
                await _unit.CommitAsync(cancellationToken);

                return CRTLeave.ToResponseWithDetails(leave);
            }
            else
            {
                throw new UnknownException(result.Message);
            }
        }
    }
}
