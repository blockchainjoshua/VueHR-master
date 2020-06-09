using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class CompAndBenTypes
    {
        public CompAndBenTypes()
        {
            CompAndBen = new HashSet<CompAndBen>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CompAndBen> CompAndBen { get; set; }
    }
}
