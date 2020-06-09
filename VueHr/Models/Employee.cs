using System;
using System.Collections.Generic;

namespace VueHr.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Allowance = new HashSet<Allowance>();
            AttendanceConfiguration = new HashSet<AttendanceConfiguration>();
            CompAndBen = new HashSet<CompAndBen>();
            Corrections = new HashSet<Corrections>();
            Deductions = new HashSet<Deductions>();
            EmployeeBackground = new HashSet<EmployeeBackground>();
           // EmployeeEducationalBackground = new HashSet<EmployeeEducationalBackground>();
            EmployeeOrganization = new HashSet<EmployeeOrganization>();
            EmployeeReferences = new HashSet<EmployeeReferences>();
            EmployeeWorkBackground = new HashSet<EmployeeWorkBackground>();
            GovContributions = new HashSet<GovContributions>();
            GovCredentials = new HashSet<GovCredentials>();
            LeaveBalances = new HashSet<LeaveBalances>();
            Memos = new HashSet<Memos>();
            Ob = new HashSet<Ob>();
            Overtime = new HashSet<Overtime>();
            PaySlip = new HashSet<PaySlip>();
            Salary = new HashSet<Salary>();
            UserCredentials = new HashSet<UserCredentials>();
            UserLeaves = new HashSet<UserLeaves>();
            UserLoan = new HashSet<UserLoan>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string CurrentAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? BiometricId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string CivilStatus { get; set; }
        public string Height { get; set; }
        public string Skin { get; set; }
        public string BloodType { get; set; }
        public string PermanentAddress { get; set; }

        public virtual EmployeeCalendar EmployeeCalendar { get; set; }
        public virtual EmployeeGovCredentials EmployeeGovCredentials { get; set; }
        public virtual ICollection<Allowance> Allowance { get; set; }
        public virtual ICollection<AttendanceConfiguration> AttendanceConfiguration { get; set; }
        public virtual ICollection<CompAndBen> CompAndBen { get; set; }
        public virtual ICollection<Corrections> Corrections { get; set; }
        public virtual ICollection<Deductions> Deductions { get; set; }
        public virtual ICollection<EmployeeBackground> EmployeeBackground { get; set; }
        public virtual List<EmployeeEducationalBackground> EmployeeEducationalBackground { get; set; }
        public virtual ICollection<EmployeeOrganization> EmployeeOrganization { get; set; }
        public virtual ICollection<EmployeeReferences> EmployeeReferences { get; set; }
        public virtual ICollection<EmployeeWorkBackground> EmployeeWorkBackground { get; set; }
        public virtual ICollection<GovContributions> GovContributions { get; set; }
        public virtual ICollection<GovCredentials> GovCredentials { get; set; }
        public virtual ICollection<LeaveBalances> LeaveBalances { get; set; }
        public virtual ICollection<Memos> Memos { get; set; }
        public virtual ICollection<Ob> Ob { get; set; }
        public virtual ICollection<Overtime> Overtime { get; set; }
        public virtual ICollection<PaySlip> PaySlip { get; set; }
        public virtual ICollection<Salary> Salary { get; set; }
        public virtual ICollection<UserCredentials> UserCredentials { get; set; }
        public virtual ICollection<UserLeaves> UserLeaves { get; set; }
        public virtual ICollection<UserLoan> UserLoan { get; set; }
    }
}
