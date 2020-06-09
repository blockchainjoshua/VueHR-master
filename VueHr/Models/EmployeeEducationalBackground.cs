using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VueHr.Models
{
    public partial class EmployeeEducationalBackground
    {
        public int Id { get; set; }
        [DisplayName("Employee Id")]
        public int? EmployeeId { get; set; }
        [DisplayName("Primary School")]
        public string Primary { get; set; }
        [DisplayName("Date Graduated")]
        public DateTime? PrimaryGradDate { get; set; }
        [DisplayName("Secondary School")]
        public string Secondary { get; set; }
        [DisplayName("Date Graduated")]
        public DateTime? SecondaryGradDate { get; set; }
        [DisplayName("Vocational School")]
        public string Vocational { get; set; }
        [DisplayName("Date Graduated")]
        public DateTime? VocationalGradDate { get; set; }
        [DisplayName("College School")]
        public string College { get; set; }
        [DisplayName("Course")]
        public string CollegeCourse { get; set; }
        [DisplayName("Date Graduated")]
        public DateTime? CollegeGradDate { get; set; }
        [DisplayName("Grad School")]
        public string GradSchool { get; set; }
        [DisplayName("Course")]
        public string GradSchoolCourse { get; set; }
        [DisplayName("Date Graduated")]
        public DateTime? GradSchoolGradDate { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
