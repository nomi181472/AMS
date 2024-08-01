using AttendanceServices.Services.ShiftManagementService.Models.Request;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Models.DomainModels;
using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.ShiftManagementService.Models.Response;
using AttendanceServices.Services.AllowanceService.Models.Response;
using AttendanceServices.Services.AllowanceService.Models;
using AttendanceServices.EnumsAndConstants.Constant;

namespace AttendanceServices.Services.ShiftManagementService.Models
{
    public class ShiftService : IShiftService
    {
        IUnitOfWork _unit;
        public ShiftService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public async Task<bool> AddShift(RequestAddShift request, string userId, CancellationToken cancellationToken)
        {
            var entity = request.ToDomain();

            if (entity == null)
            {
                throw new UnknownException("Entity is null");
            }

            entity.UpdatedBy = userId;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive = true;

            await _unit.shiftRepo.AddAsync(entity, userId, cancellationToken);
            await _unit.CommitAsync(cancellationToken);

            return true;
        }

        public async Task<List<ResponseGetShiftWithDetails>> ListWithDetails(CancellationToken cancellationToken)
        {
            var result = await _unit.shiftRepo.GetAllAsync(cancellationToken);
            List<ResponseGetShiftWithDetails> response = new List<ResponseGetShiftWithDetails>();

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

        public async Task<List<ResponseGetShiftUpdated>> UpdateShift(RequestUpdateShift request, string userId, CancellationToken cancellationToken)
        {
            /*var existingShiftResult = await _unit.shiftRepo.GetSingleAsync(
                cancellationToken,
                x => x.Code == request.Code
            );

            if (!existingShiftResult.Status || existingShiftResult.Data == null)
            {
                throw new UnknownException($"Shift with code {request.Code} not found.");
            }

            var existingShift = existingShiftResult.Data;

            existingShift.Description = request.Description != KConstantCommon.UseNA ? request.Description : existingShift.Description;
           */
            //existingShift.NumDays = request.NumDays != 0 ? request.NumDays : existingShift.NumDays;
            //existingShift.TimeIn = request.TimeIn != DateTime.MinValue ? request.TimeIn : existingShift.TimeIn;
            //existingShift.TimeOut = request.TimeOut != DateTime.MinValue ? request.TimeOut : existingShift.TimeOut;
            //existingShift.UpdatedBy = userId;
            //existingShift.UpdatedDate = DateTime.Now;
            var status = request.Status ?? KConstantCommon.UseNA;
            var result=await _unit.shiftRepo.UpdateOnConditionAsync(
                x=>x.IsActive==true&&x.Code==request.Code,///matching condition
                x=>x.SetProperty(x=>x.Description, request.Description ?? KConstantCommon.UseNA)
                .SetProperty(x=>x.Status,status)
                .SetProperty(x=>x.UpdatedBy,userId)
                .SetProperty(x=>x.UpdatedDate, DateTime.Now) //second parameter, what value need to be change it will be chain call
                , cancellationToken
                );
        

            var response = new List<ResponseGetShiftUpdated>
            {
                new ResponseGetShiftUpdated
                {
                  //  Code = existingShift.Code,
                   // Description = existingShift.Description,
                   // Status = existingShift.Status,
                   // NumDays = existingShift.NumDays,
                    //TimeIn = existingShift.TimeIn,
                   // TimeOut = existingShift.TimeOut
                }}
            ;

            if (response == null || !response.Any())
            {
                throw new UnknownException("Failed to generate a response for the updated shift. Please try again.");
            }

            return response;
        }

        public async Task<List<ResponseGetShiftDeleted>> DeleteShift(RequestDeleteShift request, string userId, CancellationToken cancellationToken)
        {
            var existingShiftResult = await _unit.shiftRepo.GetSingleAsync(
                cancellationToken,
                x => x.Code == request.Code
            );

            if (!existingShiftResult.Status || existingShiftResult.Data == null)
            {
                throw new UnknownException($"Shift with code {request.Code} not found.");
            }

            var existingShift = existingShiftResult.Data;

            var deleteResult = await _unit.shiftRepo.DeleteAsync(existingShift, cancellationToken);
            if (!deleteResult.Result)
            {
                throw new UnknownException("Failed to delete the shift. Please try again.");
            }

            await _unit.CommitAsync(cancellationToken);

            var response = new List<ResponseGetShiftDeleted>
            {
                new ResponseGetShiftDeleted
                {
                    Code = existingShift.Code,
                    Description = existingShift.Description,
                    Status = existingShift.Status,
                    NumDays = existingShift.NumDays,
                    TimeIn = existingShift.TimeIn,
                    TimeOut = existingShift.TimeOut
                }
            };

            if (response == null || !response.Any())
            {
                throw new UnknownException("Failed to generate a response for the updated shift. Please try again.");
            }

            return response;
        }

    }
}
