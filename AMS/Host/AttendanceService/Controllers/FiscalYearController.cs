using AttendanceService.Common;
using AttendanceServices.CustomExceptions.Common;
using AttendanceServices.Services.FiscalYearService;
using AttendanceServices.Services.FiscalYearService.Models.Request;
using AttendanceServices.Services.WorkingProfileService.Models.Request;
using Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PAttendanceServices.CustomExceptions.CustomExceptionMessage;
using PaymentGateway.API.Common;

namespace AttendanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiscalYearController : ControllerBase
    {
        private readonly ICustomLogger _logger;
        private readonly IFiscalYearService _fiscalYearService;

        public FiscalYearController(ICustomLogger logger, IFiscalYearService fiscalYearService)
        {
            _fiscalYearService = fiscalYearService;
            _logger = logger;
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(Create))]
        [HttpPost]
        public async Task<IActionResult> Create(CreateFiscalYearRequest request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";
                var result = await _fiscalYearService.AddFiscalYear(request, userId, cancellationToken);
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
        public async Task<IActionResult> Update(UpdateFiscalYearRequest request, CancellationToken cancellationToken)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "Success";
            try
            {
                string userId = "anyIdfornow";
                var result = await _fiscalYearService.UpdateFiscalYear(request, userId, cancellationToken);
                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                statusCode = HTTPStatusCode400.BadRequest;
                message = ExceptionMessage.NA;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
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
                var result = await _fiscalYearService.DeleteFiscalYearById(Id, userId, cancellationToken);

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (RecordNotFoundException ex)
            {
                statusCode = HTTPStatusCode400.BadRequest;
                message = ExceptionMessage.NA;
                _logger.LogError(ex.Message, ex);
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
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
                var result = await _fiscalYearService.ListAllFiscalYears(userId, cancellationToken);

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
