using AttendanceServices.Services.DeductionService.Models;
using AttendanceServices.Services.ShiftAssignmentService.Request;
using AttendanceServices.Services.ShiftAssignmentService.Response;
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
        public ShiftAssignmentService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public async Task<bool> AddShiftAssignment(RequestAddShiftWorkingProfile request, string userId, CancellationToken cancellationToken)
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
