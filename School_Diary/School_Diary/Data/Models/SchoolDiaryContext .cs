using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace School_Diary.Data.Models
{
    public partial class SchoolDiaryContext : DbContext
    {
        public SchoolDiaryContext()
        {
        }

        public SchoolDiaryContext(DbContextOptions<SchoolDiaryContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AdminsAuthentication> AdminsAuthentications { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentsAuthentication> StudentsAuthentications { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=School_Diary;Integrated Security=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminsAuthentication>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PK__Admins_A__4A30011784B0ECBF");
                entity.ToTable("Admins_Authentication");
                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Password");
                entity.Property(e => e.AdminUsername)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Username");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.GradeId).HasName("PK__Grades__D4437153C6104B97");

                entity.Property(e => e.GradeId).HasColumnName("Grade_ID");
                entity.Property(e => e.GradeName)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Grade_Name");
                entity.Property(e => e.GradeNumber).HasColumnName("Grade_Number");
                entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => e.MarkId).HasName("PK__Marks__385C0956B2503ABB");

                entity.Property(e => e.MarkId).HasColumnName("Mark_ID");
                entity.Property(e => e.DateOfAssessment).HasColumnName("Date_Of_Assessment");
                entity.Property(e => e.IsDelete).HasColumnName("isDelete");
                entity.Property(e => e.MarkLevel)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Mark_Level");
                entity.Property(e => e.MonthOfAssessment).HasColumnName("Month_Of_Assessment");
                entity.Property(e => e.SubjectId).HasColumnName("Subject_ID");
                entity.Property(e => e.YearOfAssessment).HasColumnName("Year_Of_Assessment");

                entity.HasOne(d => d.Subject).WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Marks__Subject_I__5165187F");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId).HasName("PK__Students__A2F4E9ACE521E48A");

                entity.Property(e => e.StudentId).HasColumnName("Student_ID");
                entity.Property(e => e.City)
                    .HasMaxLength(180)
                    .IsUnicode(false);
                entity.Property(e => e.Country)
                    .HasMaxLength(180)
                    .IsUnicode(false);
                entity.Property(e => e.DateOfBirth).HasColumnName("Date_Of_Birth");
                entity.Property(e => e.FamilyName)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Family_Name");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");
                entity.Property(e => e.Gender)
                    .HasMaxLength(180)
                    .IsUnicode(false);
                entity.Property(e => e.GradeId).HasColumnName("Grade_ID");
                entity.Property(e => e.IsDelete).HasColumnName("isDelete");
                entity.Property(e => e.MonthOfBirth).HasColumnName("Month_Of_Birth");
                entity.Property(e => e.SecondName)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Second_Name");
                entity.Property(e => e.YearOfBirth).HasColumnName("Year_Of_Birth");

                entity.HasOne(d => d.Grade).WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students__Grade___4BAC3F29");
            });

            modelBuilder.Entity<StudentsAuthentication>(entity =>
            {
                entity.HasKey(e => e.StudentAuthenticationId).HasName("PK__Students__3C6C1CF4038D7ECB");
                entity.ToTable("Students_Authentication");
                entity.Property(e => e.StudentAuthenticationId).HasColumnName("Student_Authentication_ID");
                entity.Property(e => e.IsDelete).HasColumnName("isDelete");
                entity.Property(e => e.StudentAuthenticationPassword)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Student_Authentication_Password");
                entity.Property(e => e.StudentAuthenticationUsername)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Student_Authentication_Username");
                entity.Property(e => e.StudentId).HasColumnName("Student_ID");

                entity.HasOne(d => d.Student).WithMany(p => p.StudentsAuthentications)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students___Stude__534D60F1");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__D98F54D696B1ABAF");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_ID");
                entity.Property(e => e.IsDelete).HasColumnName("isDelete");
                entity.Property(e => e.StudentId).HasColumnName("Student_ID");
                entity.Property(e => e.SubjectName)
                    .HasMaxLength(180)
                    .IsUnicode(false)
                    .HasColumnName("Subject_Name");

                entity.HasOne(d => d.Student).WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subjects__Studen__4E88ABD4");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}