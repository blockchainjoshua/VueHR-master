using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Period
    {
        public Period()
        {
            CompAndBen = new HashSet<CompAndBen>();
            Deductions = new HashSet<Deductions>();
            PaySlip = new HashSet<PaySlip>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public virtual ICollection<CompAndBen> CompAndBen { get; set; }
        public virtual ICollection<Deductions> Deductions { get; set; }
        public virtual ICollection<PaySlip> PaySlip { get; set; }
    }
}
