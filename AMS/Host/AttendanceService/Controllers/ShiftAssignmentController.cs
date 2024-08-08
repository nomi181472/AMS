using AttendanceService.Common;
using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.ShiftAssignmentService;
using AttendanceServices.Services.ShiftAssignmentService.Request;
using AttendanceServices.Services.ShiftManagementService.Models;
using AttendanceServices.Services.ShiftManagementService.Models.Request;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAttendanceServices.CustomExceptions.CustomExceptionMessage;
using PaymentGateway.API.Common;
using System.Net;

namespace AttendanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftAssignmentController : ControllerBase
    {
        readonly ICustomLogger _logger;
        readonly IShiftAssignmentService _shiftAssignmentService;

        public ShiftAssignmentController(ICustomLogger logger, IShiftAssignmentService shiftAssignmentService)
        {
            _logger = logger;
            _shiftAssignmentService = shiftAssignmentService;
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(AddShiftAssignment))]
        [HttpPost]
        public async Task<IActionResult> AddShiftAssignment(RequestAddShiftWorkingProfile request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success, Shift added successfully";

            try
            {
                string userId = "anyIdfornow";
                var result = await _shiftAssignmentService.AddShiftAssignment(request, userId, cancellationToken);
                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                statusCode = (int)HttpStatusCode.NotFound;
                message = "Shift Assignment not found.";
                return ApiResponseHelper.Convert(false, false, message, (int)statusCode, null);
            }
            catch (Exception e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(message, e);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }
    }
}
