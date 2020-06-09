using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? BiometricId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }
        public int? Status { get; set; }
    }
}
