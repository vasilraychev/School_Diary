using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using School_Diary.Data.Models;

namespace School_Diary.Migrations
{
    [DbContext(typeof(SchoolDiaryContext))]
    partial class SchoolDiaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("School_Diary.Data.Models.AdminsAuthentication", b =>
            {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Admin_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Admin_Password");

                    b.Property<string>("AdminUsername")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Admin_Username");

                    b.HasKey("AdminId")
                        .HasName("PK__Admins_A__4A30011784B0ECBF");

                    b.ToTable("Admins_Authentication", (string)null);
            });

            modelBuilder.Entity("School_Diary.Data.Models.Grade", b =>
            {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Grade_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<string>("GradeName")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Grade_Name");

                    b.Property<int>("GradeNumber")
                        .HasColumnType("int")
                        .HasColumnName("Grade_Number");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("isDelete");

                    b.HasKey("GradeId")
                        .HasName("PK__Grades__D4437153C6104B97");

                    b.ToTable("Grades");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Mark", b =>
            {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Mark_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<int>("DateOfAssessment")
                        .HasColumnType("int")
                        .HasColumnName("Date_Of_Assessment");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("isDelete");

                    b.Property<decimal>("MarkLevel")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("Mark_Level");

                    b.Property<int>("MonthOfAssessment")
                        .HasColumnType("int")
                        .HasColumnName("Month_Of_Assessment");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("Subject_ID");

                    b.Property<int>("YearOfAssessment")
                        .HasColumnType("int")
                        .HasColumnName("Year_Of_Assessment");

                    b.HasKey("MarkId")
                        .HasName("PK__Marks__385C0956B2503ABB");

                    b.HasIndex("SubjectId");

                    b.ToTable("Marks");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Student", b =>
            {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Student_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)");

                    b.Property<int>("DateOfBirth")
                        .HasColumnType("int")
                        .HasColumnName("Date_Of_Birth");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Family_Name");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("First_Name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)");

                    b.Property<int>("GradeId")
                        .HasColumnType("int")
                        .HasColumnName("Grade_ID");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("isDelete");

                    b.Property<int>("MonthOfBirth")
                        .HasColumnType("int")
                        .HasColumnName("Month_Of_Birth");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Second_Name");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("int")
                        .HasColumnName("Year_Of_Birth");

                    b.HasKey("StudentId")
                        .HasName("PK__Students__A2F4E9ACE521E48A");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
            });

            modelBuilder.Entity("School_Diary.Data.Models.StudentsAuthentication", b =>
            {
                    b.Property<int>("StudentAuthenticationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Student_Authentication_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentAuthenticationId"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("isDelete");

                    b.Property<string>("StudentAuthenticationPassword")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Student_Authentication_Password");

                    b.Property<string>("StudentAuthenticationUsername")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Student_Authentication_Username");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("Student_ID");

                    b.HasKey("StudentAuthenticationId")
                        .HasName("PK__Students__3C6C1CF4038D7ECB");

                    b.HasIndex("StudentId");

                    b.ToTable("Students_Authentication", (string)null);
            });

            modelBuilder.Entity("School_Diary.Data.Models.Subject", b =>
            {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Subject_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("isDelete");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("Student_ID");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(180)
                        .IsUnicode(false)
                        .HasColumnType("varchar(180)")
                        .HasColumnName("Subject_Name");

                    b.HasKey("SubjectId")
                        .HasName("PK__Subjects__D98F54D696B1ABAF");

                    b.HasIndex("StudentId");

                    b.ToTable("Subjects");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Mark", b =>
            {
                    b.HasOne("School_Diary.Data.Models.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectId")
                        .IsRequired()
                        .HasConstraintName("FK__Marks__Subject_I__5165187F");

                    b.Navigation("Subject");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Student", b =>
            {
                    b.HasOne("School_Diary.Data.Models.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId")
                        .IsRequired()
                        .HasConstraintName("FK__Students__Grade___4BAC3F29");

                    b.Navigation("Grade");
            });

            modelBuilder.Entity("School_Diary.Data.Models.StudentsAuthentication", b =>
            {
                    b.HasOne("School_Diary.Data.Models.Student", "Student")
                        .WithMany("StudentsAuthentications")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__Students___Stude__534D60F1");

                    b.Navigation("Student");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Subject", b =>
            {
                    b.HasOne("School_Diary.Data.Models.Student", "Student")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__Subjects__Studen__4E88ABD4");

                    b.Navigation("Student");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Grade", b =>
            {
                    b.Navigation("Students");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Student", b =>
            {
                    b.Navigation("StudentsAuthentications");

                    b.Navigation("Subjects");
            });

            modelBuilder.Entity("School_Diary.Data.Models.Subject", b =>
            {
                    b.Navigation("Marks");
            });
        }
    }
}
