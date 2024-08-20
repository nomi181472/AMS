using AttendanceServices.Services.ShiftDeductionSchedulerManagement.Models.Request;
using DA;
using DA.Models.DomainModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.ShiftDeductionSchedulerManagement
{
    public class ShiftDeductionSchedulerService : IShiftDeductionSchedulerService
    {
        IUnitOfWork _unit;
        public ShiftDeductionSchedulerService(IUnitOfWork unitOfWork) 
        {
            _unit = unitOfWork;
        }

        public async Task<bool> ShiftDeductionAssign(RequestAssignShiftDeduction request, string userId, CancellationToken cancellationToken)
        {
            var shift = await _unit.shiftRepo.GetSingleAsync(cancellationToken, entity => entity.Id == request.ShiftId);
            if(shift.Data == null)
            {
                throw new ArgumentException("Invalid ShiftId");            
            }

            var deduction = await _unit.deductionRepo.GetSingleAsync(cancellationToken , entity =>  entity.Id == request.DeductionId);
            if (deduction.Data == null)
            {
                throw new ArgumentException("Invalid DeductionId");
            }
            var workingprofile = await _unit.workingProfileRepo.GetSingleAsync(cancellationToken, entity => entity.Id == request.WorkingProfileId);
            if (workingprofile.Data == null)
            {
                throw new ArgumentException("Invalid WorkingProfileId");
            }

            var entity = request.ToDomain();
            entity.CreatedBy = userId;
            entity.UpdatedBy = userId;

            await _unit.shiftDeductionSchedulerRepo.AddAsync(entity, userId, cancellationToken);
            await _unit.CommitAsync(cancellationToken);
            return true;

        }
    }
}
