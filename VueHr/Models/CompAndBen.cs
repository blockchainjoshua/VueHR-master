using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class CompAndBen
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? Type { get; set; }
        public string Remarks { get; set; }
        public decimal? Amount { get; set; }
        public int? Period { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Period PeriodNavigation { get; set; }
        public virtual CompAndBenTypes TypeNavigation { get; set; }
    }
}
