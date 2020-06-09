using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class EmployeeOrganization
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string StartDate { get; set; }
        public string RegularizationDate { get; set; }
        public string ResignationDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
