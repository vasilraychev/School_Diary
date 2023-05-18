using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Diary.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins_Authentication",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Username = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    Admin_Password = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admins_A__4A30011784B0ECBF", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Grade_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade_Number = table.Column<int>(type: "int", nullable: false),
                    Grade_Name = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grades__D4437153C6104B97", x => x.Grade_ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade_ID = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    Second_Name = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    Family_Name = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    Date_Of_Birth = table.Column<int>(type: "int", nullable: false),
                    Month_Of_Birth = table.Column<int>(type: "int", nullable: false),
                    Year_Of_Birth = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    Country = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    City = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__A2F4E9ACE521E48A", x => x.Student_ID);
                    table.ForeignKey(
                        name: "FK__Students__Grade___4BAC3F29",
                        column: x => x.Grade_ID,
                        principalTable: "Grades",
                        principalColumn: "Grade_ID");
                });

            migrationBuilder.CreateTable(
                name: "Students_Authentication",
                columns: table => new
                {
                    Student_Authentication_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Student_Authentication_Username = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    Student_Authentication_Password = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__3C6C1CF4038D7ECB", x => x.Student_Authentication_ID);
                    table.ForeignKey(
                        name: "FK__Students___Stude__534D60F1",
                        column: x => x.Student_ID,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Subject_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Subject_Name = table.Column<string>(type: "varchar(180)", unicode: false, maxLength: 180, nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__D98F54D696B1ABAF", x => x.Subject_ID);
                    table.ForeignKey(
                        name: "FK__Subjects__Studen__4E88ABD4",
                        column: x => x.Student_ID,
                        principalTable: "Students",
                        principalColumn: "Student_ID");
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Mark_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_ID = table.Column<int>(type: "int", nullable: false),
                    Mark_Level = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date_Of_Assessment = table.Column<int>(type: "int", nullable: false),
                    Month_Of_Assessment = table.Column<int>(type: "int", nullable: false),
                    Year_Of_Assessment = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marks__385C0956B2503ABB", x => x.Mark_ID);
                    table.ForeignKey(
                        name: "FK__Marks__Subject_I__5165187F",
                        column: x => x.Subject_ID,
                        principalTable: "Subjects",
                        principalColumn: "Subject_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_Subject_ID",
                table: "Marks",
                column: "Subject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Grade_ID",
                table: "Students",
                column: "Grade_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Authentication_Student_ID",
                table: "Students_Authentication",
                column: "Student_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Student_ID",
                table: "Subjects",
                column: "Student_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins_Authentication");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Students_Authentication");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
