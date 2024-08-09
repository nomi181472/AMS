using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.DeductionService.Models;
using AttendanceServices.Services.ShiftAssignmentService.Models;
using AttendanceServices.Services.ShiftAssignmentService.Models.Request;
using AttendanceServices.Services.ShiftAssignmentService.Models.Response;
using AttendanceServices.Services.ShiftManagementService;
using AttendanceServices.Services.WorkingProfileService;
using DA;
using DA.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService
{
    public class ShiftAssignmentService : IShiftAssignmentService
    {
        IUnitOfWork _unit;
        private readonly IShiftService _shiftService;
        private readonly IWorkingProfileService _workingProfileService;
        public ShiftAssignmentService(IUnitOfWork unitOfWork, IShiftService shiftService, IWorkingProfileService workingProfileService)
        {
            _unit = unitOfWork;
            _shiftService = shiftService;
            _workingProfileService = workingProfileService;
        }

        public async Task<bool> AddShiftAssignment(RequestAssignShiftToWorkingProfile request, string userId, CancellationToken cancellationToken)
        {
           

            if (request == null)
            {
                throw new UnknownException("The request cannot be null.");
            }

            var searchedShift =await _shiftService.SingleWithoutDetails(request.ShiftCode! , cancellationToken);
            
            if(searchedShift == null)
            {
                throw new UnknownException("Shift does not exist with that code");
            }

            var searchedWorkingProfile = await _workingProfileService.SingleWithoutDetails(request.WorkingProfileCode! , cancellationToken);

            if(searchedWorkingProfile == null)
            {
                throw new UnknownException("Working Profile Does not exist with that code");
            }
            RequestAddShiftWorkingProfile obj = new RequestAddShiftWorkingProfile
            {
                ShiftId = searchedShift.Id,
                WorkingProfileId = searchedWorkingProfile.Id

            };
            var entity = obj.ToDomain();
            if (entity == null)
            {
                throw new UnknownException("The request is invalid and could not be converted to a domain entity.");
            }

            Expression<Func<ShiftWorkingProfile, bool>> filter = swp => swp.WorkingProfileId == searchedWorkingProfile.Id && swp.ShiftId == searchedShift.Id;
            var getterResult = await _unit.shiftWorkingProfileRepo.GetSingleAsync(cancellationToken, filter);
            if (getterResult.Data != null)
            {
                throw new UnknownException("Shift with code: " + request.ShiftCode + " is already assigned to Working Profile with code:" + searchedWorkingProfile.Code);

            }
            entity.UpdatedBy = userId;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive = true;

            await _unit.shiftWorkingProfileRepo.AddAsync(entity, userId, cancellationToken);
            await _unit.CommitAsync(cancellationToken);

            return true;
        }

        public async Task<List<ResponseGetShiftWorkingProfileWithDetails>> ListWithDetails(CancellationToken cancellationToken)
        {
           
            return null;
        }

        public Task<ResponseGetShiftWorkingProfileWithDetails> SingleWithDetails(string shiftcode, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<List<ResponseGetShiftWorkingProfileUpdated>> UpdateShiftAssignment(RequestUpdateShiftWorkingProfile request, string userId, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<List<ResponseGetShiftWorkingProfileDeleted>> DeleteShiftAssignment(RequestDeleteShiftWorkingProfile request, string userId, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
