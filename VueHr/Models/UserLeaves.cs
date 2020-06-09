using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class UserLeaves
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public short? LeaveTypeId { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? DateFiled { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public decimal? Hours { get; set; }
        public string Remarks { get; set; }
        public string Attachment { get; set; }
        public string ApprovedBy { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LeaveTypes LeaveType { get; set; }
    }
}
