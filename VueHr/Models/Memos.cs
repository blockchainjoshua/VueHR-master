using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Memos
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
        public string Attachment { get; set; }
        public string Severity { get; set; }
        public string EncodedBy { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
