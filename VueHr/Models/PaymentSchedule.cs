using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class PaymentSchedule
    {
        public int Id { get; set; }
        public int? UserLoanId { get; set; }
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public double? Amount { get; set; }

        public virtual UserLoan UserLoan { get; set; }
    }
}
