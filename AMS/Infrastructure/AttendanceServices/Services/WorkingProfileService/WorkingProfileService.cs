using AttendanceServices.Services.WorkingProfileService.Models.Request;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.WorkingProfileService
{
    public class WorkingProfileService:IWorkingProfileService
    {
        public async Task<bool> AddWorkingProfile(CreateWorkingProfileRequest request, string userId, CancellationToken cancellationToken)
        {
            return true;
        }

        public async Task<bool> UpdateWorkingProfile(UpdateWorkingProfileRequest request, string userId, CancellationToken cancellationToken)
        {
            return true;
        }

        public async Task<bool> DeleteWorkingProfileById(string Id, string UserId, CancellationToken cancellationToken)
        {
            return true; 
        }

        public async Task<List<WorkingProfile>> ListAllWorkingProfiles(string UserId, CancellationToken cancellationToken)
        {
            List<WorkingProfile> workingProfiles = new List<WorkingProfile>();
            return workingProfiles;
        }
    }
}
