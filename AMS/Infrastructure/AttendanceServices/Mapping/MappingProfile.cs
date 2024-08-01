using AttendanceServices.Services.WorkingProfileService.Models.Request;
using AttendanceServices.Services.WorkingProfileService.Models.Response;
using AutoMapper;
using DA.Models.DomainModels;

namespace AttendanceService.Mapping_Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkingProfile, ListAllWorkingProfileResponse>().ReverseMap();
            CreateMap<CreateWorkingProfileRequest, WorkingProfile>().ReverseMap();
            CreateMap<UpdateWorkingProfileRequest, WorkingProfile>().ReverseMap();
        }
    }
}
