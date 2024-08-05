using AttendanceServices.Services.FiscalYearService.Models.Request;
using AttendanceServices.Services.FiscalYearService.Models.Response;
using AutoMapper;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.FiscalYearService.Models
{
    public class FiscalYearMapping : Profile
    {
        public FiscalYearMapping() 
        {
            CreateMap<CreateFiscalYearRequest, FiscalYear>().ReverseMap();
            CreateMap<FiscalYear, FiscalYearResponse>().ReverseMap();
        }
    }
}
