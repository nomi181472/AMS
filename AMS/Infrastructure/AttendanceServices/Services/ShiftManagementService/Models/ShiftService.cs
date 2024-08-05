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
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "The request cannot be null.");
            }

            var entity = request.ToDomain();

            if (entity == null)
            {
                throw new ArgumentException("The request is invalid and could not be converted to a domain entity.", nameof(request));
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
                throw new InvalidOperationException("Failed to retrieve shift data.");
            }
        }

        public async Task<List<ResponseGetShiftUpdated>> UpdateShift(RequestUpdateShift request, string userId, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "The request cannot be null.");
            }

            var status = request.Status ?? KConstantCommon.UseNA;
            var setterResult = await _unit.shiftRepo.UpdateOnConditionAsync(
                // 1st param: matching condition
                x => x.IsActive==true&&x.Code==request.Code,
                // 2nd param: set the updated value
                x=>x.SetProperty(x=>x.Description, request.Description ?? KConstantCommon.UseNA)
                .SetProperty(x=>x.Status,status)
                .SetProperty(x=>x.UpdatedBy,userId)
                .SetProperty(x=>x.UpdatedDate, DateTime.Now)
                , cancellationToken
            );

            if (setterResult == null)
            {
                throw new InvalidOperationException("The update operation did not return a result.");
            }

            await _unit.CommitAsync(cancellationToken);

            var response = new List<ResponseGetShiftUpdated>
            {
                new ResponseGetShiftUpdated
                {
                    Code = request.Code,
                }}
            ;

            if (response == null || !response.Any())
            {
                throw new InvalidOperationException("The response list is null or empty, indicating that no shifts were updated.");
            }

            return response;
        }

        public async Task<List<ResponseGetShiftDeleted>> DeleteShift(RequestDeleteShift request, string userId, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "The request cannot be null.");
            }

            Expression<Func<Shift, bool>> filter = shift => shift.Code == request.Code && shift.IsActive == true;
            var getterResult = await _unit.shiftRepo.GetSingleAsync(cancellationToken, filter);

            if (getterResult.Status)
            {
                if (getterResult.Data != null)
                {
                    var shift = getterResult.Data;
                    shift.IsActive = false;
                    shift.IsArchived = true;
                    shift.UpdatedBy = userId;
                    shift.UpdatedDate = DateTime.Now;

                    await _unit.shiftRepo.UpdateAsync(shift, userId, cancellationToken);
                    await _unit.CommitAsync(cancellationToken);
                }
                else
                {
                    throw new RecordNotFoundException("leave Id not found.");
                }
            }
            else
            {
                throw new InvalidOperationException("Failed to retrieve the shift data.");
            }

            // ALTERNATIVE APPROACH TO SEARCH AND UPDATE 
            //Shift shiftToDelete = getterResult.Data;
            //var setterResult = await _unit.shiftRepo.UpdateOnConditionAsync(
            //    x => x.IsActive == true && x.Code == request.Code,
            //    x => x.SetProperty(shiftToDelete => shiftToDelete.IsActive, false),
            //    cancellationToken
            //);
            //
            //if (setterResult == null)
            //{
            //    throw new UnknownException(setterResult.Message);
            //}

            //await _unit.CommitAsync(cancellationToken);

            var response = new List<ResponseGetShiftDeleted>
            {
                new ResponseGetShiftDeleted
                {
                    Code = request.Code
                }}
            ;

            return response;
        }

    }
}
