using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class EmployeeReferences
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string ContactNumber { get; set; }
        public string Name { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
