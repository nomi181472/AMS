using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_File_Reader
{
    public class RequestAttendanceCsv
    {
        public int Id { get; set; }
        public TimeOnly TimeIn { get; set; }
        public TimeOnly TimeOut { get; set; }
    }
}
