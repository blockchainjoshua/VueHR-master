using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class LeaveTypes
    {
        public LeaveTypes()
        {
            UserLeaves = new HashSet<UserLeaves>();
        }

        public int? JobRoleId { get; set; }
        public short Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? TotalCredits { get; set; }

        public virtual JobRole JobRole { get; set; }
        public virtual ICollection<UserLeaves> UserLeaves { get; set; }
    }
}
