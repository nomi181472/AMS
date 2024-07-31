using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class ShiftDeductionScheduler : Base<string>
    {
        public string ShiftId { get; set; }

        public string DeductionId { get; set; }

        public Shift Shift { get; set; }

        public Deduction Deduction { get; set; }
    }
}
