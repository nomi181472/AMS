using AttendanceService.Common;
using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.DeductionService;
using AttendanceServices.Services.DeductionService.Models.Request;
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
    public class DeductionController : ControllerBase
    {
        private readonly ICustomLogger _logger;
        readonly IDeductionService _deductionService;

        public DeductionController(ICustomLogger logger, IDeductionService deductionService)
        {
            _logger = logger;
            _deductionService = deductionService;
        }

        [ProducesResponseType(HTTPStatusCode200.Created)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(AddDeduction))]
        [HttpPost]

        public async Task<IActionResult> AddDeduction(RequestAddDeduction request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _deductionService.AddDeduction(request, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (UnknownException ex)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
            catch (Exception e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(e.Message, e);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode400.NotFound)]
        [Route(nameof(GetDeductionByCode))]
        [HttpGet]
        public async Task<IActionResult> GetDeductionByCode(string deductionCode, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _deductionService.GetDeductionByCode(deductionCode, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                statusCode = HTTPStatusCode400.NotFound;
                message = ExceptionMessage.NA;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }

            catch (UnknownException e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(e.Message, e);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode400.NotFound)]
        [Route(nameof(GetDeductionById))]
        [HttpGet]
        public async Task<IActionResult> GetDeductionById(string deductionId, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _deductionService.GetDeductionById(deductionId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                statusCode = HTTPStatusCode400.NotFound;
                message = ExceptionMessage.NA;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }

            catch (UnknownException e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(e.Message, e);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }


        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(GetDeductions))]
        [HttpGet]
        public async Task<IActionResult> GetDeductions(CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _deductionService.GetDeductions(cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }

            catch (UnknownException e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(e.Message, e);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode400.NotFound)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(SoftDeleteDeduction))]
        [HttpDelete]
        public async Task<IActionResult> SoftDeleteDeduction(string deductionCode, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _deductionService.SoftDeleteDeduction(deductionCode, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                statusCode = HTTPStatusCode400.NotFound;
                message = ExceptionMessage.NA;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }
            catch (UnknownException ex)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode400.NotFound)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(UpdateDeduction))]
        [HttpPut]
        public async Task<IActionResult> UpdateDeduction([FromBody] RequestUpdateDeduction request, string deductionCode, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";// jwt context.User
                var result = await _deductionService.UpdateDeduction(request, deductionCode, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                statusCode = HTTPStatusCode400.NotFound;
                message = ExceptionMessage.NA;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
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
