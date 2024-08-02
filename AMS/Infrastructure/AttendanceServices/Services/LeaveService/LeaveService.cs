using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.LeaveService.Models;
using AttendanceServices.Services.LeaveService.Models.Request;
using AttendanceServices.Services.LeaveService.Models.Response;
using DA;
using DA.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            
            entity.Id = Guid.NewGuid().ToString();
            entity.UpdatedBy = userId;
            entity.CreatedBy = userId;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive = true;
            var result = await _unit.leaveRepo.AddAsync(entity,userId,cancellationToken);
            if(result.Result != true) // Result variable can be found in AddAsync implementation.
            {
                throw new UnknownException("Something went wrong, record not created. Error Message: " + result.Message);
            }
            await _unit.CommitAsync(cancellationToken);
            return true;

        
        
        }

        public async Task<ResponseGetLeaveWithDetails> GetLeave(string leaveId, CancellationToken cancellationToken)
        {
            var result = await _unit.leaveRepo.GetByIdAsync(leaveId,cancellationToken);
            ResponseGetLeaveWithDetails response;
            if(result.Status )
            {
                if(result.Data != null)
                {
                    response = CRTLeave.ToResponseWithDetails(result.Data);
                    return response;
                }
                else
                {
                    throw new RecordNotFoundException("Leave does not exist with Id: " + leaveId);
                }
                
            }
            else
            {
                throw new UnknownException("Error: "+result.Message);
            }
        }

        public async Task<List<ResponseGetLeaveWithDetails>> GetLeaves(CancellationToken cancellationToken)
        {
            var result = await _unit.leaveRepo.GetAllAsync(cancellationToken);
            List<ResponseGetLeaveWithDetails> response = new List<ResponseGetLeaveWithDetails>();
            if (result.Status)
            {
                if(result.Data != null)
                {
                    foreach (var record in result.Data)
                    {
                        response.Add(CRTLeave.ToResponseWithDetails(record));
                    }
                    return response;
                }
                else
                {
                    return response; // Return empty list.
                }
                
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

                    var respone = await _unit.leaveRepo.UpdateAsync(leave, userId, cancellationToken);
                    if (respone.Result)
                    {
                        await _unit.CommitAsync(cancellationToken);
                        return true;
                    }
                    else
                    {
                        throw new UnknownException("Error: "+respone.Message);
                    }
                    
                }
                else
                {
                    throw new RecordNotFoundException("Leave does not exist with Id: " + leaveId);
                }
            }
            else
            {
                throw new UnknownException("Error: " + result.Message) ;
            }
        }

        public async Task<ResponseGetLeaveWithDetails> UpdateLeave(RequestUpdateLeave request, string leaveId, string userId, CancellationToken cancellationToken)
        {
            var result = await _unit.leaveRepo.GetByIdAsync(leaveId, cancellationToken);

            if (result.Status)
            {
                if (result.Data != null)
                {
                    var leave = result.Data;
                    leave.Code = request.Code;
                    leave.Name = request.Name;
                    leave.Description = request.Description;
                    leave.CompanyId = request.CompanyId;
                    leave.UpdatedBy = userId;
                    leave.UpdatedDate = DateTime.Now;

                    var response = await _unit.leaveRepo.UpdateAsync(leave, userId, cancellationToken);
                    if(response.Result)
                    {
                        await _unit.CommitAsync(cancellationToken);
                        return CRTLeave.ToResponseWithDetails(leave);
                    }
                    else
                    {
                        throw new UnknownException("Error: " +response.Message);
                    }
                    
                }
                else
                {
                    throw new RecordNotFoundException("Leave does not exist with Id: " + leaveId);
                }
                
            }
            else
            {
                throw new UnknownException(result.Message);
            }
        }
    }
}
