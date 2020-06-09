using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class PaySlip
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public double? Salary { get; set; }
        public double? HalfMonthSalary { get; set; }
        public int? SalaryType { get; set; }
        public double? PaidLeaves { get; set; }
        public string Allowance { get; set; }
        public string CompAndBen { get; set; }
        public int? Deductions { get; set; }
        public string Loans { get; set; }
        public int? Period { get; set; }

        public virtual Deductions DeductionsNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Period PeriodNavigation { get; set; }
    }
}
