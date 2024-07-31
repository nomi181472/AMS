using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    internal class Shift : Base<string>
    {

        public string? Description { get; set; }
        public Enum? Status { get; set; }

        public Enum? Days { get; set; }
        public TimeOnly? TimeIn { get; set; }
        public TimeOnly? TimeOut { get; set; }
        public TimeOnly? BreakOut { get; set; }
        public TimeOnly? BreakIn { get; set; }

        public TimeOnly? BreakDuration { get; set; }

        private TimeOnly? WorkDuration { get; set; }

    }
}
