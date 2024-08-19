using Microsoft.AspNetCore.Mvc;
using CsvUtility;
using PaymentGateway.API.Common;
using Logger;
using AttendanceService.Common;
using AttendanceServices.CustomExceptions.Common;
using PAttendanceServices.CustomExceptions.CustomExceptionMessage;
using System.Net;
using System.Threading;
using CSV_File_Reader;
using System.Net.Http;
using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System;

namespace YourWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CsvController : ControllerBase
    {
        private readonly ICsvService _csvService;
        private readonly ICustomLogger _logger;

        public CsvController(ICustomLogger logger, ICsvService csvService)
        {
            _logger = logger;
            _csvService = csvService;
        }

        [ProducesResponseType(HTTPStatusCode200.Ok)]
        [ProducesResponseType(HTTPStatusCode500.InternalServerError)]
        [Route(nameof(UploadCsv))]
        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            int statusCode = HTTPStatusCode200.Ok;
            string message = "";

            try
            {
                var data = await _csvService.ProcessCsvFileAsync(file.OpenReadStream());
                return ApiResponseHelper.Convert(true, true, message, statusCode, data);
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                statusCode = (int)HttpStatusCode.NotFound;
                message = "Invalid Request";
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


    }
}
