using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Deductions
    {
        public Deductions()
        {
            PaySlip = new HashSet<PaySlip>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? TypeId { get; set; }
        public int? Period { get; set; }
        public double? Amount { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Period PeriodNavigation { get; set; }
        public virtual DeductionType Type { get; set; }
        public virtual ICollection<PaySlip> PaySlip { get; set; }
    }
}
