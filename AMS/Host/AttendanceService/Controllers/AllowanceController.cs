using AttendanceService.Common;
using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.AllowanceService;
using AttendanceServices.Services.AllowanceService.Models.Request;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PAttendanceServices.CustomExceptions.CustomExceptionMessage;
using PaymentGateway.API.Common;

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
    
        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        

        [Route(nameof(AddAllowance))]
        [HttpPost]

        public async Task<IActionResult> AddAllowance(RequestAddAllowance request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            
            try
            {
                string userId ="anyIdfornow";// jwt context.User
                var result = await _allowanceService.AddAllowance(request, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            
            catch (Exception e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(message, e);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }
        [ProducesResponseType(HTTPStatusCode200.Ok)]
       
        [Route(nameof(ListAllWithDetails))]
        [HttpGet]
        public async Task<IActionResult> ListAllWithDetails(CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "";
            try
            {
                var result = await _allowanceService.ListWithDetails(cancellationToken);
                message = $"Total: {result.Count()}";

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message, e);
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }


    }
}
