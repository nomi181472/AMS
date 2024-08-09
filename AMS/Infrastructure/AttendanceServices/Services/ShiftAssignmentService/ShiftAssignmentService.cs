using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.DeductionService.Models;
using AttendanceServices.Services.ShiftAssignmentService.Models;
using AttendanceServices.Services.ShiftAssignmentService.Models.Request;
using AttendanceServices.Services.ShiftAssignmentService.Models.Response;
using AttendanceServices.Services.ShiftManagementService;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftAssignmentService
{
    public class ShiftAssignmentService : IShiftAssignmentService
    {
        IUnitOfWork _unit;
        ShiftService _shiftService;
        public ShiftAssignmentService(IUnitOfWork unitOfWork, ShiftService shiftService)
        {
            _unit = unitOfWork;
            _shiftService = shiftService;
        }

        public async Task<bool> AddShiftAssignment(RequestAddShiftWorkingProfile request, string userId, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new UnknownException("The request cannot be null.");
            }

            var entity = request.ToDomain();

            if (entity == null)
            {
                throw new UnknownException("The request is invalid and could not be converted to a domain entity.");
            }

            var searchedShift = _shiftService.SingleWithoutDetails(request.ShiftId , cancellationToken);
            
            if(searchedShift == null)
            {
                throw new UnknownException("Shift does not exist with that code");
            }

            // do same validation for WorkingProfile

            entity.UpdatedBy = userId;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive = true;

            await _unit.shiftWorkingProfileRepo.AddAsync(entity, userId, cancellationToken);
            await _unit.CommitAsync(cancellationToken);

            return true;
        }

        public Task<List<ResponseGetShiftWorkingProfileWithDetails>> ListWithDetails(CancellationToken cancellationToken)
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
