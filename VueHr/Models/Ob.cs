using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Ob
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Start { get; set; }
        public TimeSpan? End { get; set; }
        public decimal? Hours { get; set; }
        public DateTime? DateFiled { get; set; }
        public bool? IsApproved { get; set; }
        public string Remarks { get; set; }
        public string Attachment { get; set; }
        public string ApprovedBy { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
