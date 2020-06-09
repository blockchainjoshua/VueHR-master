using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class JobRole
    {
        public JobRole()
        {
            LeaveTypes = new HashSet<LeaveTypes>();
            Position = new HashSet<Position>();
        }

        public int Id { get; set; }
        public int? OrgId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Organization Org { get; set; }
        public virtual ICollection<LeaveTypes> LeaveTypes { get; set; }
        public virtual ICollection<Position> Position { get; set; }
    }
}
