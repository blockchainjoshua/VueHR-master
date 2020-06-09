using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class UserLoan
    {
        public UserLoan()
        {
            LoanPayments = new HashSet<LoanPayments>();
            PaymentSchedule = new HashSet<PaymentSchedule>();
        }

        public int Id { get; set; }
        public int? Type { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? TotalAmount { get; set; }
        public double? Balance { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LoanTypes TypeNavigation { get; set; }
        public virtual ICollection<LoanPayments> LoanPayments { get; set; }
        public virtual ICollection<PaymentSchedule> PaymentSchedule { get; set; }
    }
}
