using AttendanceServices.Services.AllowanceService;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowanceController : ControllerBase
    {
        readonly ICustomLogger _logger;
        readonly IAllowanceService _allowanceService;
        public AllowanceController( IAllowanceService allowanceService)
        {
            _allowanceService = allowanceService;
        }

        
    }
}
