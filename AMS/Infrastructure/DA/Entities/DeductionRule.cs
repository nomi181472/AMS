using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Entities
{
    public class DeductionRule
    {
        public Guid Code { get; set; }
        public string Name { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public long Count { get; set; }

        public long Value { get; set; }


    }
}
