using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employee_management_system.Migrations
{
    /// <inheritdoc />
    public partial class NavigationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_DepartmentID",
                table: "Supervisors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_TaskID",
                table: "Supervisors",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TaskID",
                table: "Employees",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserID",
                table: "Employees",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CEOs_UserID",
                table: "CEOs",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CEOs_Users_UserID",
                table: "CEOs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Tasks_TaskID",
                table: "Employees",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserID",
                table: "Employees",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Departments_DepartmentID",
                table: "Supervisors",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_Tasks_TaskID",
                table: "Supervisors",
                column: "TaskID",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CEOs_Users_UserID",
                table: "CEOs");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Tasks_TaskID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Departments_DepartmentID",
                table: "Supervisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_Tasks_TaskID",
                table: "Supervisors");

            migrationBuilder.DropIndex(
                name: "IX_Supervisors_DepartmentID",
                table: "Supervisors");

            migrationBuilder.DropIndex(
                name: "IX_Supervisors_TaskID",
                table: "Supervisors");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TaskID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_CEOs_UserID",
                table: "CEOs");
        }
    }
}
