using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.FiscalYearService.Models.Request;
using AttendanceServices.Services.FiscalYearService.Models.Response;
using AttendanceServices.Services.WorkingProfileService.Models.Request;
using AttendanceServices.Services.WorkingProfileService.Models.Response;
using AutoMapper;
using DA;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.FiscalYearService
{
    public class FiscalYearService:IFiscalYearService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FiscalYearService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddFiscalYear(CreateFiscalYearRequest request, string userId, CancellationToken cancellationToken)
        {
            FiscalYear fiscalYear = _mapper.Map<CreateFiscalYearRequest, FiscalYear>(request);
            fiscalYear.Id = Guid.NewGuid().ToString();
            fiscalYear.IsActive = true;
            fiscalYear.IsArchived = false;
            var result = await _unitOfWork.fiscalYearRepo.AddAsync(fiscalYear, userId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            if (result.IsException || result.Result == false)
            {
                throw new Exception("Something went wrong");
            }
            return result.Result;
        }

        public async Task<bool> UpdateFiscalYear(UpdateFiscalYearRequest request, string userId, CancellationToken cancellationToken)
        {
            FiscalYear? fiscalYear = _unitOfWork.fiscalYearRepo.GetByIdAsync(request.Id ?? "", cancellationToken).Result?.Data;
            if (fiscalYear == null)
            {
                throw new RecordNotFoundException("Fiscal year you are trying to update does not exist.");
            }
            fiscalYear.Name = request.Name ?? "";
            fiscalYear.type = request.type ?? "";
            fiscalYear.StartDate = Convert.ToDateTime(request.StartDate);
            fiscalYear.EndDate = Convert.ToDateTime(request.EndDate);
            var result = await _unitOfWork.fiscalYearRepo.UpdateAsync(fiscalYear, userId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Result;
        }

        public async Task<bool> DeleteFiscalYearById(string Id, string UserId, CancellationToken cancellationToken)
        {
            FiscalYear? fiscalYear = _unitOfWork.fiscalYearRepo.GetByIdAsync(Id ?? "", cancellationToken).Result?.Data;
            if (fiscalYear == null)
            {
                throw new RecordNotFoundException("Fiscal year you are trying to delete does not exist.");
            }
            fiscalYear.IsActive = false;
            var result = await _unitOfWork.fiscalYearRepo.UpdateAsync(fiscalYear, UserId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Result;
        }

        public async Task<List<FiscalYearResponse>> ListAllFiscalYears(string userId, CancellationToken cancellationToken)
        {
            List<FiscalYearResponse> fiscalYearResponseList = new List<FiscalYearResponse>();
            IEnumerable<FiscalYear> fiscalYears = _unitOfWork.fiscalYearRepo.GetAllAsync(cancellationToken).Result.Data.Where(x => x.IsActive == true);
            foreach (FiscalYear fiscalYear in fiscalYears)
            {
                FiscalYearResponse fiscalYearResponse = new FiscalYearResponse();
                fiscalYearResponse = _mapper.Map<FiscalYear, FiscalYearResponse>(fiscalYear);
                fiscalYearResponseList.Add(fiscalYearResponse);
            }
            return fiscalYearResponseList;
        }
    }
}
