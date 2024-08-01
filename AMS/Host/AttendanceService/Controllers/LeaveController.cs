using AttendanceService.Common;
using AttendanceServices.Services.LeaveService;
using AttendanceServices.Services.LeaveService.Models.Request;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAttendanceServices.CustomExceptions.CustomExceptionMessage;
using PaymentGateway.API.Common;

namespace AttendanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ICustomLogger _logger;
        readonly ILeaveService _leaveService;

        public LeaveController(ICustomLogger logger, ILeaveService leaveService)
        {
            _logger = logger;
            _leaveService = leaveService;
        }


        [ProducesResponseType(HTTPStatusCode200.Created)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(AddLeave))]
        [HttpPost]

        public async Task<IActionResult> AddLeave(RequestAddLeave request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _leaveService.AddLeave(request, userId, cancellationToken);

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
        [ProducesResponseType(HTTPStatusCode400.NotFound)]
        [Route(nameof(GetLeave))]
        [HttpGet]
        public async Task<IActionResult> GetLeave(string leaveId, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _leaveService.GetLeave(leaveId, cancellationToken);

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
        [Route(nameof(GetLeaves))]
        [HttpGet]
        public async Task<IActionResult> GetLeaves(CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _leaveService.GetLeaves(cancellationToken);

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
        [ProducesResponseType(HTTPStatusCode400.NotFound)]
        [Route(nameof(SoftDeleteLeave))]
        [HttpDelete]
        public async Task<IActionResult> SoftDeleteLeave(string leaveId, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _leaveService.SoftDeleteLeave(leaveId,userId,cancellationToken);

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
        [ProducesResponseType(HTTPStatusCode400.NotFound)]
        [Route(nameof(UpdateLeave))]
        [HttpDelete]
        public async Task<IActionResult> UpdateLeave(RequestUpdateLeave request, string leaveId, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _leaveService.UpdateLeave(request,leaveId, userId, cancellationToken);

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
    }
}