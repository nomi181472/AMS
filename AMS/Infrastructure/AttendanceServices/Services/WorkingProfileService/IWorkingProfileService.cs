using AttendanceServices.Services.AllowanceService.Models.Request;
using AttendanceServices.Services.WorkingProfileService.Models.Request;
using AttendanceServices.Services.WorkingProfileService.Models.Response;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.WorkingProfileService
{
    public interface IWorkingProfileService
    {
        Task<bool> AddWorkingProfile(CreateWorkingProfileRequest request, string userId, CancellationToken cancellationToken);
        Task<bool> UpdateWorkingProfile(UpdateWorkingProfileRequest request, string UserId, CancellationToken cancellationToken);
        Task<bool> DeleteWorkingProfileById(string Id, string UserId, CancellationToken cancellationToken);
        Task<List<WorkingProfileResponse>> ListAllWorkingProfiles(string UserId, CancellationToken cancellationToken);
    }
}
