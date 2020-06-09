using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class AppRole
    {
        public AppRole()
        {
            Permissions = new HashSet<Permissions>();
            UserCredentials = new HashSet<UserCredentials>();
        }

        public int Id { get; set; }
        public int? OrgId { get; set; }
        public string Title { get; set; }

        public virtual Organization Org { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
        public virtual ICollection<UserCredentials> UserCredentials { get; set; }
    }
}
