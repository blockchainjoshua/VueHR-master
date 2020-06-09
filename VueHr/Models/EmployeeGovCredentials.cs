using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class EmployeeGovCredentials
    {
        public int EmployeeId { get; set; }
        public string Tin { get; set; }
        public string Sss { get; set; }
        public string Pagibig { get; set; }
        public string Philhealth { get; set; }
        public string Ctc { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
