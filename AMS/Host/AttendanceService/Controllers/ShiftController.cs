using AttendanceService.Common;
using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.AllowanceService.Models.Request;
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
    public class ShiftController : ControllerBase
    {
        readonly ICustomLogger _logger;
        readonly IShiftService _shiftService;

        public ShiftController(ICustomLogger logger, IShiftService shiftService)
        {
            _logger = logger;
            _shiftService = shiftService;
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(AddShift))]
        [HttpPost]
        public async Task<IActionResult> AddShift(RequestAddShift request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success, Shift added successfully";

            try
            {
                string userId = "anyIdfornow";
                var result = await _shiftService.AddShift(request, userId, cancellationToken);
                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                statusCode = (int)HttpStatusCode.NotFound;
                message = "Shift not found.";
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

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [Route(nameof(ListAllWithDetails))]
        [HttpGet]
        public async Task<IActionResult> ListAllWithDetails(CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "";

            try
            {
                var result = await _shiftService.ListWithDetails(cancellationToken);
                message = $"Total: {result.Count()}";
                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                statusCode = (int)HttpStatusCode.NotFound;
                message = "Shift not found.";
                return ApiResponseHelper.Convert(false, false, message, (int)statusCode, null);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(UpdateShift))]
        [HttpPost]
        public async Task<IActionResult> UpdateShift(RequestUpdateShift request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success, Shift updated successfully";

            try
            {
                string userId = "DUMMY_ID";
                var result = await _shiftService.UpdateShift(request, userId, cancellationToken);

                if (result == null || !result.Any())
                {
                    statusCode = HTTPStatusCode500.InternalServerError;
                    message = "Failed to update shift. Please try again.";
                    _logger.LogError(message);
                    return ApiResponseHelper.Convert(false, false, message, statusCode, null);
                }

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                statusCode = (int)HttpStatusCode.NotFound;
                message = "Shift not found.";
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

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode400.BadRequest)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(DeleteShift))]
        [HttpDelete]
        public async Task<IActionResult> DeleteShift([FromBody] RequestDeleteShift request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Shift deleted successfully";

            try
            {
                string userId = "DUMMY_ID";
                var result = await _shiftService.DeleteShift(request, userId, cancellationToken);

                if (result == null || result.Count == 0)
                {
                    statusCode = HTTPStatusCode400.BadRequest;
                    message = "No shift found to delete.";
                    return ApiResponseHelper.Convert(false, false, message, statusCode, null);
                }

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                statusCode = (int) HttpStatusCode.NotFound;
                message = "Shift not found.";
                return ApiResponseHelper.Convert(false, false, message, (int)statusCode, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                statusCode = HTTPStatusCode500.InternalServerError;
                message = "An unexpected error occurred while deleting the shift.";
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }
    }
}