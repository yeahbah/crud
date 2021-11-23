using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudDemo.Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentCode);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Department",
                        principalColumn: "DepartmentCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEntityProjectEntity",
                columns: table => new
                {
                    Ref_EmployeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ref_ProjectsCreatedProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEntityProjectEntity", x => new { x.Ref_EmployeesId, x.Ref_ProjectsCreatedProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeEntityProjectEntity_Employee_Ref_EmployeesId",
                        column: x => x.Ref_EmployeesId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEntityProjectEntity_Project_Ref_ProjectsCreatedProjectId",
                        column: x => x.Ref_ProjectsCreatedProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentCode", "Name" },
                values: new object[,]
                {
                    { "IT", "Information Technology" },
                    { "SALES", "Sales" },
                    { "AD", "Advertising" },
                    { "SUP", "Tech Support" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentCode",
                table: "Employee",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEntityProjectEntity_Ref_ProjectsCreatedProjectId",
                table: "EmployeeEntityProjectEntity",
                column: "Ref_ProjectsCreatedProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEntityProjectEntity");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
