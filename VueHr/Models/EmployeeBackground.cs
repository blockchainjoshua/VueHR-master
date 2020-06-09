using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class EmployeeBackground
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Type { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
