using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class UserCredentials
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? AppRole { get; set; }

        public virtual AppRole AppRoleNavigation { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
