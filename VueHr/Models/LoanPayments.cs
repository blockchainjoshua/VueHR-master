using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class LoanPayments
    {
        public int Id { get; set; }
        public int? UserLoanId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }

        public virtual UserLoan UserLoan { get; set; }
    }
}
