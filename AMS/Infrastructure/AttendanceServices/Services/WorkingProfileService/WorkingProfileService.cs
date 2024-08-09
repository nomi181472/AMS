using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.WorkingProfileService.Models.Request;
using AttendanceServices.Services.WorkingProfileService.Models.Response;
using AutoMapper;
using DA;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.WorkingProfileService
{
    public class WorkingProfileService:IWorkingProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WorkingProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddWorkingProfile(CreateWorkingProfileRequest request, string userId, CancellationToken cancellationToken)
        {
            WorkingProfile workingProfile = _mapper.Map<CreateWorkingProfileRequest, WorkingProfile>(request);
            workingProfile.Id = Guid.NewGuid().ToString();
            workingProfile.IsActive = true;
            workingProfile.IsArchived = false;
            var result = await _unitOfWork.workingProfileRepo.AddAsync(workingProfile, userId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            if(result.IsException || result.Result == false)
            {
                throw new Exception("Something went wrong");
            }
            return result.Result;
        }

        public async Task<bool> UpdateWorkingProfile(UpdateWorkingProfileRequest request, string userId, CancellationToken cancellationToken)
        {
            WorkingProfile? workingProfile = _unitOfWork.workingProfileRepo.GetByIdAsync(request.Id ?? "", cancellationToken).Result?.Data;
            if(workingProfile == null)
            {
                throw new RecordNotFoundException("Working profile you are trying to update does not exist.");
            }
            if (string.IsNullOrWhiteSpace(request.Code))
            {
                throw new Exception("Invalid working profile code");
            }
            workingProfile.Code = request.Code;
            workingProfile.GraceTimeOut = request.GraceTimeOut ?? 0;
            workingProfile.GraceTimeIn = request.GraceTimeIn ?? 0;
            workingProfile.WorkingDays = request.WorkingDays ?? 0;
            workingProfile.WorkingHours = request.WorkingHours ?? 0;
            workingProfile.Description = request.Description;
            workingProfile.FiscalYearId = request.FiscalYearId;
            var result = await _unitOfWork.workingProfileRepo.UpdateAsync(workingProfile, userId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Result;
        }

        public async Task<bool> DeleteWorkingProfileById(string Id, string UserId, CancellationToken cancellationToken)
        {
            WorkingProfile? workingProfile = _unitOfWork.workingProfileRepo.GetByIdAsync(Id ?? "", cancellationToken).Result?.Data;
            if (workingProfile == null)
            {
                throw new RecordNotFoundException("Working profile you are trying to delete does not exist.");
            }
            workingProfile.IsActive = false;
            var result = await _unitOfWork.workingProfileRepo.UpdateAsync(workingProfile, UserId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Result; 
        }

        public async Task<List<WorkingProfileResponse>> ListAllWorkingProfiles(string UserId, CancellationToken cancellationToken)
        {
            List<WorkingProfileResponse> workingProfileResponseList = new List<WorkingProfileResponse>();
            IEnumerable<WorkingProfile> workingProfiles = _unitOfWork.workingProfileRepo.GetAsync(cancellationToken, x => x.IsActive == true).Result.Data;
            foreach (WorkingProfile workingProfile in workingProfiles)
            {
                WorkingProfileResponse workingProfileResponse = new WorkingProfileResponse();
                workingProfileResponse = _mapper.Map<WorkingProfile, WorkingProfileResponse>(workingProfile);
                workingProfileResponseList.Add(workingProfileResponse);
            }
            return workingProfileResponseList;
        }

        // This functions are to be consumed by other services

        public async Task<WorkingProfile> SingleWithoutDetails(string workingProfileCode, CancellationToken cancellationToken)
        {
            Expression<Func<WorkingProfile, bool>> filter = workingprofile => workingprofile.Code == workingProfileCode && workingprofile.IsActive == true;
            var getterResult = await _unitOfWork.workingProfileRepo.GetSingleAsync(cancellationToken, filter);

            
            WorkingProfile response;
            if (getterResult.Status)
            {
                if (getterResult.Data != null)
                {
                    response = getterResult.Data;
                    return response;
                }
                else
                {
                    throw new RecordNotFoundException("Working Profile does not exist with Code: " + workingProfileCode);
                }
            }
            else
            {
                throw new InvalidOperationException($"An error occurred while processing the request: {getterResult.Message}");
            }
        }
    }
}
