using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class DeductionType
    {
        public DeductionType()
        {
            Deductions = new HashSet<Deductions>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Deductions> Deductions { get; set; }
    }
}
