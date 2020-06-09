using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Allowance
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Title { get; set; }
        public decimal? Amount { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
