namespace AWContextLibrary.AWModels.HumanResources
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext()
            : base("name=HumanResourcesContext")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_Temporal> Employee_Temporal { get; set; }
        public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual DbSet<JobCandidate> JobCandidates { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Employee_Temporal_History> Employee_Temporal_History { get; set; }
        public virtual DbSet<vEmployee> vEmployees { get; set; }
        public virtual DbSet<vEmployeeDepartment> vEmployeeDepartments { get; set; }
        public virtual DbSet<vEmployeeDepartmentHistory> vEmployeeDepartmentHistories { get; set; }
        public virtual DbSet<vEmployeePersonTemporalInfo> vEmployeePersonTemporalInfoes { get; set; }
        public virtual DbSet<vJobCandidate> vJobCandidates { get; set; }
        public virtual DbSet<vJobCandidateEducation> vJobCandidateEducations { get; set; }
        public virtual DbSet<vJobCandidateEmployment> vJobCandidateEmployments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.EmployeeDepartmentHistories)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeeDepartmentHistories)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.EmployeePayHistories)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee_Temporal>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<Employee_Temporal>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<EmployeePayHistory>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Shift>()
                .HasMany(e => e.EmployeeDepartmentHistories)
                .WithRequired(e => e.Shift)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee_Temporal_History>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<Employee_Temporal_History>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<vEmployeePersonTemporalInfo>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength();

            modelBuilder.Entity<vEmployeePersonTemporalInfo>()
                .Property(e => e.Gender)
                .IsFixedLength();
        }
    }
}
