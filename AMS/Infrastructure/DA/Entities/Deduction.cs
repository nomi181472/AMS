using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Entities
{
    public class Deduction
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
