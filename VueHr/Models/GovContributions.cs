using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class GovContributions
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Title { get; set; }
        public double? Amount { get; set; }
        public DateTime? Date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
