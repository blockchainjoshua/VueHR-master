using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Organization
    {
        public Organization()
        {
            AppRole = new HashSet<AppRole>();
            JobRole = new HashSet<JobRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OperatingHours { get; set; }

        public virtual ICollection<AppRole> AppRole { get; set; }
        public virtual ICollection<JobRole> JobRole { get; set; }
    }
}
