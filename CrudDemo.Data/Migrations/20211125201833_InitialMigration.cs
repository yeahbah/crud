using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudDemo.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentCode);
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
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Employee_EmployeeEntityId",
                        column: x => x.EmployeeEntityId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentCode", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { "AD", null, "Advertising" },
                    { "IT", null, "Information Technology" },
                    { "SALES", null, "Sales" },
                    { "SUP", null, "Tech Support" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentCode",
                table: "Employee",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_EmployeeId",
                table: "EmployeeProject",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EmployeeEntityId",
                table: "Project",
                column: "EmployeeEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
