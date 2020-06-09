using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class EmployeeCalendar
    {
        public int EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? Status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
