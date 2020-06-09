using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Department
    {
        public Department()
        {
            Position = new HashSet<Position>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Position> Position { get; set; }
    }
}
