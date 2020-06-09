using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Position
    {
        public int Id { get; set; }
        public int? JobRoleId { get; set; }
        public int? DepartmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }

        public virtual Department Department { get; set; }
        public virtual JobRole JobRole { get; set; }
    }
}
