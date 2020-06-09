using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VueHr.Models
{
    public partial class VueHrContext : DbContext
    {
        public VueHrContext()
        {
        }

        public VueHrContext(DbContextOptions<VueHrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allowance> Allowance { get; set; }
        public virtual DbSet<AppRole> AppRole { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<AttendanceConfiguration> AttendanceConfiguration { get; set; }
        public virtual DbSet<AttendanceStatus> AttendanceStatus { get; set; }
        public virtual DbSet<CompAndBen> CompAndBen { get; set; }
        public virtual DbSet<CompAndBenTypes> CompAndBenTypes { get; set; }
        public virtual DbSet<Corrections> Corrections { get; set; }
        public virtual DbSet<DeductionType> DeductionType { get; set; }
        public virtual DbSet<Deductions> Deductions { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeBackground> EmployeeBackground { get; set; }
        public virtual DbSet<EmployeeCalendar> EmployeeCalendar { get; set; }
        public virtual DbSet<EmployeeEducationalBackground> EmployeeEducationalBackground { get; set; }
        public virtual DbSet<EmployeeGovCredentials> EmployeeGovCredentials { get; set; }
        public virtual DbSet<EmployeeOrganization> EmployeeOrganization { get; set; }
        public virtual DbSet<EmployeeReferences> EmployeeReferences { get; set; }
        public virtual DbSet<EmployeeWorkBackground> EmployeeWorkBackground { get; set; }
        public virtual DbSet<EmploymentStatusTypes> EmploymentStatusTypes { get; set; }
        public virtual DbSet<GovContributions> GovContributions { get; set; }
        public virtual DbSet<GovCredentials> GovCredentials { get; set; }
        public virtual DbSet<GovDocuments> GovDocuments { get; set; }
        public virtual DbSet<JobRole> JobRole { get; set; }
        public virtual DbSet<LeaveBalances> LeaveBalances { get; set; }
        public virtual DbSet<LeaveTypes> LeaveTypes { get; set; }
        public virtual DbSet<LoanPayments> LoanPayments { get; set; }
        public virtual DbSet<LoanTypes> LoanTypes { get; set; }
        public virtual DbSet<Memos> Memos { get; set; }
        public virtual DbSet<Ob> Ob { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Overtime> Overtime { get; set; }
        public virtual DbSet<PaySlip> PaySlip { get; set; }
        public virtual DbSet<PaymentSchedule> PaymentSchedule { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<UserCredentials> UserCredentials { get; set; }
        public virtual DbSet<UserLeaves> UserLeaves { get; set; }
        public virtual DbSet<UserLoan> UserLoan { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Allowance>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(6,4)");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Allowance)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Allowance_EmployeeId_fkey");
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.HasIndex(e => e.OrgId)
                    .HasName("indx_orgId");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.AppRole)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("AppRole_OrgId_fkey");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TimeIn).HasColumnType("time without time zone");

                entity.Property(e => e.TimeOut).HasColumnType("time without time zone");
            });

            modelBuilder.Entity<AttendanceConfiguration>(entity =>
            {
                entity.Property(e => e.AdditionalMinutesBeforeOt).HasColumnName("AdditionalMinutesBeforeOT");

                entity.Property(e => e.AllowOffsettingOfOt).HasColumnName("AllowOffsettingOfOT");

                entity.Property(e => e.RequiredWorkingHours).HasColumnType("numeric(2,2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AttendanceConfiguration)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("AttendanceConfiguration_EmployeeId_fkey");
            });

            modelBuilder.Entity<AttendanceStatus>(entity =>
            {
                entity.Property(e => e.Title).HasColumnType("bit varying(50)[]");
            });

            modelBuilder.Entity<CompAndBen>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(6,4)");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CompAndBen)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("CompAndBen_EmployeeId_fkey");

                entity.HasOne(d => d.PeriodNavigation)
                    .WithMany(p => p.CompAndBen)
                    .HasForeignKey(d => d.Period)
                    .HasConstraintName("CompAndBen_Period_fkey");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.CompAndBen)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("CompAndBen_Type_fkey");
            });

            modelBuilder.Entity<CompAndBenTypes>(entity =>
            {
                entity.Property(e => e.Title).HasColumnType("character varying(50)[]");
            });

            modelBuilder.Entity<Corrections>(entity =>
            {
                entity.Property(e => e.ApprovedBy).HasColumnType("character varying(50)[]");

                entity.Property(e => e.Attachment).HasColumnType("character varying(255)[]");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.End).HasColumnType("time without time zone");

                entity.Property(e => e.Remarks).HasColumnType("character varying(100)[]");

                entity.Property(e => e.Start).HasColumnType("time without time zone");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Corrections)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Corrections_EmployeeId_fkey");
            });

            modelBuilder.Entity<DeductionType>(entity =>
            {
                entity.Property(e => e.Title).HasColumnType("character varying(50)[]");
            });

            modelBuilder.Entity<Deductions>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("fki_employeeid1");

                entity.HasIndex(e => e.Period)
                    .HasName("fki_periodId");

                entity.HasIndex(e => e.TypeId)
                    .HasName("fki_deductionTypeId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Deductions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Deductions_EmployeeId_fkey1");

                entity.HasOne(d => d.PeriodNavigation)
                    .WithMany(p => p.Deductions)
                    .HasForeignKey(d => d.Period)
                    .HasConstraintName("Deductions_Period_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Deductions)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Deductions_TypeId_fkey");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Age).HasMaxLength(3);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BloodType).HasMaxLength(5);

                entity.Property(e => e.CivilStatus).HasMaxLength(10);

                entity.Property(e => e.CurrentAddress).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Height).HasMaxLength(8);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Middlename).HasMaxLength(50);

                entity.Property(e => e.PermanentAddress).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PlaceOfBirth).HasMaxLength(100);

                entity.Property(e => e.Religion).HasMaxLength(50);

                entity.Property(e => e.Skin).HasMaxLength(10);

                entity.Property(e => e.Weight).HasMaxLength(8);
            });

            modelBuilder.Entity<EmployeeBackground>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.End).HasMaxLength(5);

                entity.Property(e => e.Start).HasMaxLength(5);

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.Property(e => e.Type).HasColumnType("character varying");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeBackground)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("EmployeeBackground_EmployeeId_fkey");
            });

            modelBuilder.Entity<EmployeeCalendar>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("EmployeeCalendar_pkey");

                entity.Property(e => e.EmployeeId).HasDefaultValueSql("nextval('\"EmployeeCalendar_Id_seq\"'::regclass)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DayOfWeek).HasMaxLength(10);

                entity.Property(e => e.EndTime).HasColumnType("time without time zone");

                entity.Property(e => e.StartTime).HasColumnType("time without time zone");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeeCalendar)
                    .HasForeignKey<EmployeeCalendar>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeeCalendar_EmployeeId_fkey");
            });

            modelBuilder.Entity<EmployeeEducationalBackground>(entity =>
            {
                entity.Property(e => e.College).HasMaxLength(255);

                entity.Property(e => e.CollegeCourse).HasMaxLength(100);

                entity.Property(e => e.CollegeGradDate).HasColumnType("date");

                entity.Property(e => e.GradSchool).HasMaxLength(255);

                entity.Property(e => e.GradSchoolCourse).HasMaxLength(100);

                entity.Property(e => e.GradSchoolGradDate).HasColumnType("date");

                entity.Property(e => e.Primary).HasMaxLength(255);

                entity.Property(e => e.PrimaryGradDate).HasColumnType("date");

                entity.Property(e => e.Secondary).HasMaxLength(255);

                entity.Property(e => e.SecondaryGradDate).HasColumnType("date");

                entity.Property(e => e.Vocational).HasMaxLength(255);

                entity.Property(e => e.VocationalGradDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeEducationalBackground)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("EmployeeEducationalBackground_EmployeeId_fkey");
            });

            modelBuilder.Entity<EmployeeGovCredentials>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("EmployeeGovCredentials_pkey");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Ctc)
                    .HasColumnName("CTC")
                    .HasMaxLength(30);

                entity.Property(e => e.Pagibig).HasMaxLength(30);

                entity.Property(e => e.Philhealth).HasMaxLength(30);

                entity.Property(e => e.Sss)
                    .HasColumnName("SSS")
                    .HasMaxLength(30);

                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.EmployeeGovCredentials)
                    .HasForeignKey<EmployeeGovCredentials>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EmployeeGovCredentials_EmployeeId_fkey");
            });

            modelBuilder.Entity<EmployeeOrganization>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"EmploymentStatus_Id_seq\"'::regclass)");

                entity.Property(e => e.RegularizationDate).HasMaxLength(20);

                entity.Property(e => e.ResignationDate).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeOrganization)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("EmploymentStatus_EmployeeId_fkey");
            });

            modelBuilder.Entity<EmployeeReferences>(entity =>
            {
                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.ContactNumber).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeReferences)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("EmployeeReferences_EmployeeId_fkey");
            });

            modelBuilder.Entity<EmployeeWorkBackground>(entity =>
            {
                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.ContactNumber).HasMaxLength(20);

                entity.Property(e => e.From).HasColumnType("date");

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(255);

                entity.Property(e => e.To).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeWorkBackground)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("EmployeeWorkBackground_EmployeeId_fkey");
            });

            modelBuilder.Entity<EmploymentStatusTypes>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(25);
            });

            modelBuilder.Entity<GovContributions>(entity =>
            {
                entity.Property(e => e.Title).HasColumnType("character varying(50)[]");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.GovContributions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("GovContributions_EmployeeId_fkey");
            });

            modelBuilder.Entity<GovCredentials>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("fki_employeeid");

                entity.Property(e => e.LastUpdate).HasColumnType("timestamp(6) without time zone[]");

                entity.Property(e => e.Title).HasColumnType("character varying(20)[]");

                entity.Property(e => e.Value).HasColumnType("character varying(20)[]");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.GovCredentials)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("GovCredentials_EmployeeId_fkey");
            });

            modelBuilder.Entity<GovDocuments>(entity =>
            {
                entity.Property(e => e.Attachment).HasColumnType("character varying(20)[]");

                entity.Property(e => e.Title).HasColumnType("character varying(20)[]");

                entity.HasOne(d => d.GovCredentials)
                    .WithMany(p => p.GovDocuments)
                    .HasForeignKey(d => d.GovCredentialsId)
                    .HasConstraintName("GovDocuments_GovCredentialsId_fkey");
            });

            modelBuilder.Entity<JobRole>(entity =>
            {
                entity.HasIndex(e => e.OrgId)
                    .HasName("indx_orgId1");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.JobRole)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("JobRole_OrgId_fkey1");
            });

            modelBuilder.Entity<LeaveBalances>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("numeric(2,2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveBalances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("LeaveBalances_EmployeeId_fkey");
            });

            modelBuilder.Entity<LeaveTypes>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.TotalCredits).HasColumnType("numeric(4,2)");

                entity.HasOne(d => d.JobRole)
                    .WithMany(p => p.LeaveTypes)
                    .HasForeignKey(d => d.JobRoleId)
                    .HasConstraintName("LeaveTypes_JobRoleId_fkey");
            });

            modelBuilder.Entity<LoanPayments>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(12,4)");

                entity.HasOne(d => d.UserLoan)
                    .WithMany(p => p.LoanPayments)
                    .HasForeignKey(d => d.UserLoanId)
                    .HasConstraintName("LoanPayments_UserLoanId_fkey");
            });

            modelBuilder.Entity<LoanTypes>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Requirements).HasColumnType("character varying");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Memos>(entity =>
            {
                entity.Property(e => e.Attachment).HasColumnType("character varying");

                entity.Property(e => e.EncodedBy)
                    .HasColumnName("Encoded By")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks).HasColumnType("character varying");

                entity.Property(e => e.Severity).HasColumnType("character varying");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Memos)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Memos_EmployeeId_fkey");
            });

            modelBuilder.Entity<Ob>(entity =>
            {
                entity.ToTable("OB");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.Attachment).HasColumnType("character varying");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DateFiled).HasColumnType("date");

                entity.Property(e => e.End).HasColumnType("time without time zone");

                entity.Property(e => e.Hours).HasColumnType("numeric(12,2)");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.Start).HasColumnType("time without time zone");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Ob)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("OB_EmployeeId_fkey");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.OperatingHours).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.Property(e => e.ApprovedBy).HasColumnType("character varying(50)[]");

                entity.Property(e => e.Attachment).HasColumnType("character varying(255)[]");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DateFiled).HasColumnType("date");

                entity.Property(e => e.End).HasColumnType("time without time zone");

                entity.Property(e => e.Hours).HasColumnType("numeric(12,2)");

                entity.Property(e => e.Remarks).HasColumnType("character varying(100)[]");

                entity.Property(e => e.Start).HasColumnType("time without time zone");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Overtime)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Overtime_EmployeeId_fkey");
            });

            modelBuilder.Entity<PaySlip>(entity =>
            {
                entity.Property(e => e.Allowance).HasColumnType("character varying(255)[]");

                entity.Property(e => e.CompAndBen).HasColumnType("character varying(255)[]");

                entity.Property(e => e.Loans).HasColumnType("character varying(255)[]");

                entity.HasOne(d => d.DeductionsNavigation)
                    .WithMany(p => p.PaySlip)
                    .HasForeignKey(d => d.Deductions)
                    .HasConstraintName("PaySlip_Deductions_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PaySlip)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("PaySlip_EmployeeId_fkey");

                entity.HasOne(d => d.PeriodNavigation)
                    .WithMany(p => p.PaySlip)
                    .HasForeignKey(d => d.Period)
                    .HasConstraintName("PaySlip_Period_fkey");
            });

            modelBuilder.Entity<PaymentSchedule>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.UserLoan)
                    .WithMany(p => p.PaymentSchedule)
                    .HasForeignKey(d => d.UserLoanId)
                    .HasConstraintName("PaymentSchedule_UserLoanId_fkey");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.Property(e => e.Title).HasColumnType("character varying(50)[]");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasIndex(e => e.AppRoleId)
                    .HasName("indx_approle");

                entity.Property(e => e.Description).HasColumnType("character varying(100)[]");

                entity.Property(e => e.Title).HasColumnType("character varying(50)[]");

                entity.HasOne(d => d.AppRole)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.AppRoleId)
                    .HasConstraintName("Permissions_AppRoleId_fkey");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("Position_DepartmentId_fkey");

                entity.HasOne(d => d.JobRole)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.JobRoleId)
                    .HasConstraintName("Position_JobRoleId_fkey");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(12,4)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Salary_EmployeeId_fkey");
            });

            modelBuilder.Entity<Shifts>(entity =>
            {
                entity.Property(e => e.EndTime).HasColumnType("time without time zone");

                entity.Property(e => e.RestDay).HasMaxLength(20);

                entity.Property(e => e.StartTime).HasColumnType("time without time zone");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.WorkDays).HasMaxLength(50);
            });

            modelBuilder.Entity<UserCredentials>(entity =>
            {
                entity.HasIndex(e => e.AppRole)
                    .HasName("indx_approleId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("indx_employeeId");

                entity.Property(e => e.Password).HasColumnType("character varying(255)[]");

                entity.Property(e => e.Username).HasColumnType("character varying(20)[]");

                entity.HasOne(d => d.AppRoleNavigation)
                    .WithMany(p => p.UserCredentials)
                    .HasForeignKey(d => d.AppRole)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UserCredentials_AppRole_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserCredentials)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserCredentials_EmployeeId_fkey");
            });

            modelBuilder.Entity<UserLeaves>(entity =>
            {
                entity.HasIndex(e => e.LeaveTypeId)
                    .HasName("fki_leavetypeId");

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.Attachment).HasMaxLength(256);

                entity.Property(e => e.Hours).HasColumnType("numeric(12,2)");

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserLeaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserLeaves_EmployeeId_fkey");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.UserLeaves)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .HasConstraintName("UserLeaves_LeaveTypeId_fkey");
            });

            modelBuilder.Entity<UserLoan>(entity =>
            {
                entity.Property(e => e.TotalAmount).HasColumnType("numeric(12,4)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.UserLoan)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("UserLoan_EmployeeId_fkey");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.UserLoan)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("UserLoan_Type_fkey");
            });

            modelBuilder.HasSequence<int>("EmployeeCalendar_Id_seq");

            modelBuilder.HasSequence<int>("EmploymentStatus_Id_seq");
        }
    }
}
