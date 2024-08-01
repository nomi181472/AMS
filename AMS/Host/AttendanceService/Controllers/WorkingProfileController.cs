using AttendanceService.Common;
using AttendanceServices.Services.AllowanceService;
using AttendanceServices.Services.WorkingProfileService;
using AttendanceServices.Services.WorkingProfileService.Models.Request;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAttendanceServices.CustomExceptions.CustomExceptionMessage;
using PaymentGateway.API.Common;
using System.Threading;

namespace AttendanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingProfileController : ControllerBase
    {
        private readonly ICustomLogger _logger;
        private readonly IWorkingProfileService _workingProfileService;
        public WorkingProfileController(ICustomLogger logger, IWorkingProfileService workingProfileService)
        {
            _logger = logger;
            _workingProfileService = workingProfileService;
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(Create))]
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkingProfileRequest request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";
                var result = await _workingProfileService.AddWorkingProfile(request, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch(Exception ex)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(Update))]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateWorkingProfileRequest request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";
                var result = await _workingProfileService.UpdateWorkingProfile(request, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (Exception ex)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(DeleteById))]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(string Id, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";
                var result = await _workingProfileService.DeleteWorkingProfileById(Id, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (Exception ex)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(ListAll))]
        [HttpGet]
        public async Task<IActionResult> ListAll(CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";
                var result = await _workingProfileService.ListAllWorkingProfiles(userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch(Exception ex)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }
    }
}
