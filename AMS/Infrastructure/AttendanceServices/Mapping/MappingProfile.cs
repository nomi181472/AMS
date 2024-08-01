﻿using AttendanceServices.Services.WorkingProfileService.Models.Response;
using AutoMapper;
using DA.Models.DomainModels;

namespace AttendanceService.Mapping_Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkingProfile, ListAllWorkingProfileResponse>().ReverseMap();
        }
    }
}
