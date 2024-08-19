using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CSV_File_Reader;
using CsvHelper;

namespace CsvUtility
{
    public class CsvService : ICsvService // RENAME THIS TO AttendanceCsvService FOR strategy/factory IN FUTURE
    {
        public async Task<List<RequestAttendanceCsv>> ProcessCsvFileAsync(Stream fileStream)
        {
            if (fileStream == null)
            {
                throw new ArgumentNullException(nameof(fileStream), "The filestream cannot be null.");
            }

            var data = new List<RequestAttendanceCsv>();

            if (data == null)
            {
                throw new ArgumentException("The filestream is invalid and could not be converted to data", nameof(fileStream));
            }

            try
            {
                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    data = csv.GetRecords<RequestAttendanceCsv>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }

            return data;
        }


    }
}
