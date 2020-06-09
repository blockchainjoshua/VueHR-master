using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class LeaveBalances
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? LeaveId { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
