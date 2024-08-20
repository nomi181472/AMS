using AttendanceService.Common;
using AttendanceServices.Services.AllowanceService.Models.Request;
using AttendanceServices.Services.ShiftDeductionSchedulerManagement;
using AttendanceServices.Services.ShiftDeductionSchedulerManagement.Models.Request;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAttendanceServices.CustomExceptions.CustomExceptionMessage;
using PaymentGateway.API.Common;

namespace AttendanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftDeductionSchedulerController : ControllerBase
    {
        private readonly ICustomLogger _logger;
        private readonly IShiftDeductionSchedulerService _shiftDeductionSchedulerService;

        public ShiftDeductionSchedulerController(ICustomLogger customLogger, IShiftDeductionSchedulerService shiftDeductionSchedulerService)
        {
            _logger = customLogger;
            _shiftDeductionSchedulerService = shiftDeductionSchedulerService;
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(AssignShiftDeduction))]
        [HttpPost]
        public async Task<IActionResult> AssignShiftDeduction(RequestAssignShiftDeduction request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";

            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _shiftDeductionSchedulerService.ShiftDeductionAssign(request, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }

            catch (Exception e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW + e.Message;
                _logger.LogError(message, e);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }
    }
}
