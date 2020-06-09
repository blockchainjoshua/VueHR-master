using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class EmployeeWorkBackground
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Reason { get; set; }
        public string ContactNumber { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
