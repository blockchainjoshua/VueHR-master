using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class LoanTypes
    {
        public LoanTypes()
        {
            UserLoan = new HashSet<UserLoan>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }

        public virtual ICollection<UserLoan> UserLoan { get; set; }
    }
}
