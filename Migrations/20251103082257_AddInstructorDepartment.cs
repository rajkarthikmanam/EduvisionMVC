using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduvisionMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructorDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Instructors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "", "CS" },
                    { 2, "", "Math" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Gpa", "Major", "Name" },
                values: new object[,]
                {
                    { 1, 20, 3.70m, "CS", "Ava" },
                    { 2, 21, 3.50m, "Math", "Liam" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Credits", "DepartmentId", "Dept", "Title" },
                values: new object[,]
                {
                    { 1, "CS101", 3, 1, "", "Intro CS" },
                    { 2, "MTH201", 4, 2, "", "Calculus I" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "gray@univ.edu", "Dr.", "Gray" },
                    { 2, 2, "hall@univ.edu", "Dr.", "Hall" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "Numeric_Grade", "StudentId", "Term" },
                values: new object[,]
                {
                    { 1, 1, 3.8m, 1, "Fall 2025" },
                    { 2, 2, 3.6m, 2, "Fall 2025" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Code_DepartmentId",
                table: "Courses",
                columns: new[] { "Code", "DepartmentId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Code_DepartmentId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Instructors");
        }
    }
}
