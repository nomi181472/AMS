﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModels
{
    public class Shift : Base<string>
    {
        public string Code { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int NumDays { get; set; } // 1 = Monday, 2 = Tuesday...
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public virtual ICollection<ShiftDeductionScheduler> ShiftDeductionScheduler { get; set; }= new List<ShiftDeductionScheduler>(); 
    }
}
