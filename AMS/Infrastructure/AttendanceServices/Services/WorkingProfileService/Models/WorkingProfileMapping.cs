using AttendanceServices.Services.WorkingProfileService.Models.Request;
using AttendanceServices.Services.WorkingProfileService.Models.Response;
using AutoMapper;
using DA.Models.DomainModels;

namespace AttendanceServices.Services.WorkingProfileService.Models
{
    public class WorkingProfileMapping : Profile
    {
        public WorkingProfileMapping()
        {
            CreateMap<WorkingProfile, WorkingProfileResponse>().ReverseMap();
            CreateMap<CreateWorkingProfileRequest, WorkingProfile>().ReverseMap();
            CreateMap<UpdateWorkingProfileRequest, WorkingProfile>().ReverseMap();
        }
    }
}
