using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class GovDocuments
    {
        public int Id { get; set; }
        public int? GovCredentialsId { get; set; }
        public string Title { get; set; }
        public string Attachment { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual GovCredentials GovCredentials { get; set; }
    }
}
