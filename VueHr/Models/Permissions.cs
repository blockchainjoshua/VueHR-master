using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Permissions
    {
        public int Id { get; set; }
        public int? AppRoleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual AppRole AppRole { get; set; }
    }
}
