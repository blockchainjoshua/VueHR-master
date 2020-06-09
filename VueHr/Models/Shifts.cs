using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Shifts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string WorkDays { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string RestDay { get; set; }
    }
}
