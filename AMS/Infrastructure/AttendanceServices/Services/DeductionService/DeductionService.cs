using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.DeductionService.Models;
using AttendanceServices.Services.DeductionService.Models.Request;
using AttendanceServices.Services.DeductionService.Models.Response;
using AttendanceServices.Services.LeaveService.Models;
using AttendanceServices.Services.LeaveService.Models.Response;
using DA;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.DeductionService
{
    public class DeductionService : IDeductionService
    {
        IUnitOfWork _unit;

        public DeductionService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<bool> AddDeduction(RequestAddDeduction request, string userId, CancellationToken cancellationToken)
        {
            var entity =  CRTDeduction.ToDomain(request);
            entity.Id =   Guid.NewGuid().ToString();
            entity.UpdatedBy = userId;
            entity.CreatedBy = userId;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive = true;
            var result = await _unit.deductionRepo.AddAsync(entity, userId, cancellationToken);
            if (result.Result != true) // Result variable can be found in AddAsync implementation.
            {
                throw new UnknownException("Something went wrong, record not created. Error Message: " + result.Message);
            }
            await _unit.CommitAsync(cancellationToken);
            return true;

        }

        public async Task<ResponseGetDeductionWithDetails> GetDeductionByCode(string deductionCode, CancellationToken cancellationToken)
        {
            Expression<Func<Deduction, bool>> filter = deduction => deduction.Code == deductionCode && deduction.IsActive == true;

            var result = await  _unit.deductionRepo.GetSingleAsync(cancellationToken, filter);
            ResponseGetDeductionWithDetails response;

            if(result.Status)
            {
                if(result.Data  != null)
                {
                    response = CRTDeduction.ToResponseWithDetails(result.Data);
                    return response;
                }
                else
                {
                    throw new RecordNotFoundException("Deduction does not exist with Code: " + deductionCode);
                }

            }
            else
            {
                throw new UnknownException("Error: " + result.Message);
            }
        }

        public async Task<ResponseGetDeductionWithDetails> GetDeductionById(string deductionId, CancellationToken cancellationToken)
        {
            var result = await _unit.deductionRepo.GetByIdAsync(deductionId, cancellationToken);
            ResponseGetDeductionWithDetails response;
            if (result.Status)
            {
                if (result.Data != null)
                {
                    response = CRTDeduction.ToResponseWithDetails(result.Data);
                    return response;
                }
                else
                {
                    throw new RecordNotFoundException("Deduction does not exist with Code: " + deductionId);
                }

            }
            else
            {
                throw new UnknownException("Error: " + result.Message);
            }
        }

        public async Task<List<ResponseGetDeductionWithDetails>> GetDeductions(CancellationToken cancellationToken)
        {
            var result = await _unit.deductionRepo.GetAllAsync(cancellationToken);
            List<ResponseGetDeductionWithDetails> response = new List<ResponseGetDeductionWithDetails>();
            if (result.Status)
            {
                if (result.Data != null)
                {
                    foreach (var record in result.Data)
                    {
                        response.Add(CRTDeduction.ToResponseWithDetails(record));
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

        public async Task<bool> SoftDeleteDeduction(string deductionCode, string userId, CancellationToken cancellationToken)
        {
            Expression<Func<Deduction, bool>> filter = deduction => deduction.Code == deductionCode && deduction.IsActive == true;
            var result = await _unit.deductionRepo.GetSingleAsync(cancellationToken, filter);
            if (result.Status)
            {
                if (result.Data != null)
                {
                    var deduction = result.Data;
                    deduction.IsActive = false;
                    deduction.IsArchived = true;
                    deduction.UpdatedBy = userId;
                    deduction.UpdatedDate = DateTime.Now;

                    var respone = await _unit.deductionRepo.UpdateAsync(deduction, userId, cancellationToken);
                    if (respone.Result)
                    {
                        await _unit.CommitAsync(cancellationToken);
                        return true;
                    }
                    else
                    {
                        throw new UnknownException("Error: " + respone.Message);
                    }

                }
                else
                {
                    throw new RecordNotFoundException("Deduction does not exist with Code: " + deductionCode);
                }
            }
            else
            {
                throw new UnknownException("Error: " + result.Message);
            }

        }

        public async Task<ResponseGetDeductionWithDetails> UpdateDeduction(RequestUpdateDeduction request, string deductionCode, string userId, CancellationToken cancellationToken)
        {
            Expression<Func<Deduction, bool>> filter = deduction => deduction.Code == deductionCode && deduction.IsActive == true;
            var result = await _unit.deductionRepo.GetSingleAsync(cancellationToken, filter);

            if (result.Status)
            {
                if (result.Data != null)
                {
                    var deduction = result.Data;
                    deduction.Code = request.Code;
                    deduction.Name = request.Name;
                    deduction.Description = request.Description;
                    deduction.Type = request.Type;
                    deduction.UpdatedBy = userId;
                    deduction.UpdatedDate = DateTime.Now;

                    var response = await _unit.deductionRepo.UpdateAsync(deduction, userId, cancellationToken);
                    if (response.Result)
                    {
                        await _unit.CommitAsync(cancellationToken);
                        return CRTDeduction.ToResponseWithDetails(deduction);
                    }
                    else
                    {
                        throw new UnknownException("Error: " + response.Message);
                    }

                }
                else
                {
                    throw new RecordNotFoundException("Deduction does not exist with Code: " + deductionCode);
                }

            }
            else
            {
                throw new UnknownException(result.Message);
            }
        }
    }
}
