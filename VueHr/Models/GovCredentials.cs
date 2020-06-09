using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class GovCredentials
    {
        public GovCredentials()
        {
            GovDocuments = new HashSet<GovDocuments>();
        }

        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<GovDocuments> GovDocuments { get; set; }
    }
}
