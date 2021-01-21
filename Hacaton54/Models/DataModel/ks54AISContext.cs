using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hacaton54.Models.DataModel
{
    public partial class ks54AISContext : DbContext
    {
        public ks54AISContext()
        {
        }

        public ks54AISContext(DbContextOptions<ks54AISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attestation> Attestations { get; set; }
        public virtual DbSet<AttestationForm> AttestationForms { get; set; }
        public virtual DbSet<AttestationStudent> AttestationStudents { get; set; }
        public virtual DbSet<CourseWork> CourseWorks { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<DisciplineEmployee> DisciplineEmployees { get; set; }
        public virtual DbSet<DisciplineIndex> DisciplineIndices { get; set; }
        public virtual DbSet<EducationDepartment> EducationDepartments { get; set; }
        public virtual DbSet<EducationInstitution> EducationInstitutions { get; set; }
        public virtual DbSet<EducationInstitutionType> EducationInstitutionTypes { get; set; }
        public virtual DbSet<EducationSertificate> EducationSertificates { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupSpeciality> GroupSpecialities { get; set; }
        public virtual DbSet<GroupType> GroupTypes { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderGroup> OrderGroups { get; set; }
        public virtual DbSet<OrderScan> OrderScans { get; set; }
        public virtual DbSet<OrderStudent> OrderStudents { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<ParentStudent> ParentStudents { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<PassportScan> PassportScans { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RoadMap> RoadMaps { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<TypeSertificate> TypeSertificates { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=84.38.189.95,31760;Database=ks54AIS;User=hacaton54;Password=zxcv777qwer;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Attestation>(entity =>
            {
                entity.ToTable("Attestation");

                entity.HasOne(d => d.DisciplineEmployee)
                    .WithMany(p => p.Attestations)
                    .HasForeignKey(d => d.DisciplineEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attestation_DisciplineEmployee");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Attestations)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attestation_AttestationForm");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.Attestations)
                    .HasForeignKey(d => d.MonthId)
                    .HasConstraintName("FK_Attestation_Month");
            });

            modelBuilder.Entity<AttestationForm>(entity =>
            {
                entity.ToTable("AttestationForm");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AttestationStudent>(entity =>
            {
                entity.ToTable("AttestationStudent");

                entity.Property(e => e.HoldingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Attestation)
                    .WithMany(p => p.AttestationStudents)
                    .HasForeignKey(d => d.AttestationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttestationStudent_Attestation");

                entity.HasOne(d => d.Score)
                    .WithMany(p => p.AttestationStudents)
                    .HasForeignKey(d => d.ScoreId)
                    .HasConstraintName("FK_AttestationStudent_Score");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AttestationStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttestationStudent_Student");
            });

            modelBuilder.Entity<CourseWork>(entity =>
            {
                entity.ToTable("CourseWork");

                entity.Property(e => e.DeadLine).HasColumnType("date");

                entity.Property(e => e.Topic).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CourseWorks)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CourseWork_Employee");

                entity.HasOne(d => d.Score)
                    .WithMany(p => p.CourseWorks)
                    .HasForeignKey(d => d.ScoreId)
                    .HasConstraintName("FK_CourseWork_Score");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseWorks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseWork_Student");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.ToTable("Discipline");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.DisciplineIndex)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.DisciplineIndexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Discipline_DisciplineIndex");
            });

            modelBuilder.Entity<DisciplineEmployee>(entity =>
            {
                entity.ToTable("DisciplineEmployee");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.DisciplineEmployees)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DisciplineEmployee_Discipline");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DisciplineEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DisciplineEmployee_Employee");
            });

            modelBuilder.Entity<DisciplineIndex>(entity =>
            {
                entity.ToTable("DisciplineIndex");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EducationDepartment>(entity =>
            {
                entity.ToTable("EducationDepartment");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.HeadOfDepartmentNavigation)
                    .WithMany(p => p.EducationDepartments)
                    .HasForeignKey(d => d.HeadOfDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationDepartment_Employee");
            });

            modelBuilder.Entity<EducationInstitution>(entity =>
            {
                entity.ToTable("EducationInstitution");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.EducationInstitutions)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationInstitution_Region");

                entity.HasOne(d => d.TypeInstitution)
                    .WithMany(p => p.EducationInstitutions)
                    .HasForeignKey(d => d.TypeInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationInstitution_EducationInstitutionType");
            });

            modelBuilder.Entity<EducationInstitutionType>(entity =>
            {
                entity.ToTable("EducationInstitutionType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EducationSertificate>(entity =>
            {
                entity.ToTable("EducationSertificate");

                entity.Property(e => e.AvgScore).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.SertificateNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EducationInstitution)
                    .WithMany(p => p.EducationSertificates)
                    .HasForeignKey(d => d.EducationInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationSertificate_EducationInstitution");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.EducationSertificates)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationSertificate_Student");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.EducationSertificates)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationSertificate_TypeSertificate");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.EMail)
                    .HasMaxLength(100)
                    .HasColumnName("E_mail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Gender");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmployeePosition");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Employee_Users");
            });

            modelBuilder.Entity<EmployeePosition>(entity =>
            {
                entity.ToTable("EmployeePosition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.EducationBeginDate).HasColumnType("date");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Curator)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CuratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Employee");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_EducationDepartment");

                entity.HasOne(d => d.GroupSpeciality)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupSpecialityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_GroupSpeciality");

                entity.HasOne(d => d.GroupType)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.GroupTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_GroupType");
            });

            modelBuilder.Entity<GroupSpeciality>(entity =>
            {
                entity.ToTable("GroupSpeciality");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpecialityCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<GroupType>(entity =>
            {
                entity.ToTable("GroupType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.ToTable("Month");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasOne(d => d.OrderType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderType");
            });

            modelBuilder.Entity<OrderGroup>(entity =>
            {
                entity.ToTable("OrderGroup");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.OrderGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderGroup_Groups");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderGroups)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderGroup_Order");
            });

            modelBuilder.Entity<OrderScan>(entity =>
            {
                entity.ToTable("OrderScan");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderScans)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderScan_Order");
            });

            modelBuilder.Entity<OrderStudent>(entity =>
            {
                entity.ToTable("OrderStudent");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderStudents)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderStudent_Order");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.OrderStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderStudent_Student");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("OrderType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("Parent");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ParentStudent>(entity =>
            {
                entity.ToTable("ParentStudent");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ParentStudents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentStudent_Parent");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ParentStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentStudent_Student");
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.ToTable("Passport");

                entity.Property(e => e.DivisionCode)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.IssuedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Passports)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passport_Student");
            });

            modelBuilder.Entity<PassportScan>(entity =>
            {
                entity.ToTable("PassportScan");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(d => d.Passport)
                    .WithMany(p => p.PassportScans)
                    .HasForeignKey(d => d.PassportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PassportScan_Passport");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.Name).HasMaxLength(70);
            });

            modelBuilder.Entity<RoadMap>(entity =>
            {
                entity.ToTable("RoadMap");

                entity.Property(e => e.Year).HasColumnType("date");

                entity.HasOne(d => d.Attestation)
                    .WithMany(p => p.RoadMaps)
                    .HasForeignKey(d => d.AttestationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoadMap_Attestation");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.RoadMaps)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoadMap_Groups");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("Score");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdressFact).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.EMail)
                    .HasMaxLength(100)
                    .HasColumnName("E_mail");

                entity.Property(e => e.HousePhone).HasMaxLength(20);

                entity.Property(e => e.Inn)
                    .HasMaxLength(20)
                    .HasColumnName("INN");

                entity.Property(e => e.MedPolicy).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Snils).HasMaxLength(20);

                entity.Property(e => e.SurName).HasMaxLength(100);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Student_Gender");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Student_Groups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Student_Users");
            });

            modelBuilder.Entity<TypeSertificate>(entity =>
            {
                entity.ToTable("TypeSertificate");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
