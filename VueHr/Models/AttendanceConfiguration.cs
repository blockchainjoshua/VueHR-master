using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class AttendanceConfiguration
    {
        public int Id { get; set; }
        public TimeSpan? LateGracePeriod { get; set; }
        public bool? NoLatesOrUndertime { get; set; }
        public bool? RoundOffLates { get; set; }
        public int? TardinessMultiplier { get; set; }
        public bool? UseTardinessBrackets { get; set; }
        public TimeSpan? MaximumBreakTime { get; set; }
        public TimeSpan? RequireLunchBreakAfter { get; set; }
        public bool? EmployeeHasNoAbsent { get; set; }
        public decimal? RequiredWorkingHours { get; set; }
        public TimeSpan? HalfDayIfTardinessReached { get; set; }
        public TimeSpan? AbsentIfTardinessReached { get; set; }
        public bool? AllowOffsettingOfOt { get; set; }
        public int? OvertimeMultiplier { get; set; }
        public TimeSpan? AdditionalMinutesBeforeOt { get; set; }
        public TimeSpan? AllowedTimeInEarlyOffset { get; set; }
        public DateTime? StartOfScheduleOffset { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
