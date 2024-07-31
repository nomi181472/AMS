﻿using AttendanceServices.EnumsAndConstants.Constant;
using AttendanceServices.Services.AllowanceService.Models.Response;
using DA.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceServices.Services.AllowanceService.Models.Request
{
    public class RequestAddAllowance
    {
        public string Code { get; set; } = KConstantCommon.UseNA;
        public string Name { get; set; } = KConstantCommon.UseNA;
        public string Description { get; set; } = KConstantCommon.UseNA;
        public int CompanyId { get; set; }
    }
    
}
