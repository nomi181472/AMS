using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_File_Reader
{
    public interface ICsvService
    {
        public Task<List<RequestAttendanceCsv>> ProcessCsvFileAsync(Stream fileStream);

    }
}
