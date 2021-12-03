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
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
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
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Employee_CreatedByEmployeeId",
                        column: x => x.CreatedByEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
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
                    { "BOARD", null, "Leadership" },
                    { "ENG", null, "Engineering" },
                    { "IT", null, "Information Technology" },
                    { "LOG", null, "Logistics" },
                    { "RKT", null, "Rockets" },
                    { "SUP", null, "Tech Support" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "BirthDate", "DepartmentCode", "Email", "FirstName", "IsDeleted", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0167754b-bab2-4f82-aca2-00c658ff7042"), new DateTime(1985, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOG", "mynamejeff@spacey.com", "Jeff", null, "Beshoes", "" },
                    { new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUP", "", "System", null, "System", "" },
                    { new Guid("76eafd92-0122-4619-82ef-d39538679e55"), new DateTime(1980, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ENG", "toinfinityandbeyond@spacey.com", "Bus", null, "Lightyear", "2223334444" },
                    { new Guid("955644f9-3f3d-4ca3-a5c3-b22a306d2668"), new DateTime(1985, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "RKT", "iloverockets@spacey.com", "Robert", null, "Goddard", "" },
                    { new Guid("9f64cc03-d96e-43e5-9f6a-fa8da71f1cd5"), new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOARD", "mars@spacey.com", "Yellon", null, "Mask", "1112223333" },
                    { new Guid("e890ea76-7c81-42a4-9eab-e9a1498a353c"), new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOARD", "bill.cool@spacey.com", "Bill", null, "Geyts", "1112223333" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "CreatedByEmployeeId", "CreatedTimestamp", "Description", "IsDeleted", "Name", "UpdatedByEmployeeId", "UpdatedTimestamp" },
                values: new object[,]
                {
                    { new Guid("2f111ec5-56d4-452a-89e7-faa4ca0df624"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3152), "The JSAT constellation is a communication and broadcasting satellite constellation formerly operated by JSAT Corporation and currently by SKY Perfect JSAT Group. It has become the most important commercial constellation in Japan, and the fifth of the world. It has practically amalgamated all private satellite operators in Japan, with only B-SAT left as a local competitor.", null, "JCSAT", null, null },
                    { new Guid("52c82ac7-73b6-433b-af00-f5601902227f"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3133), "In 2017, Iridium began launching Iridium NEXT, a second-generation worldwide network of telecommunications satellites, consisting of 66 active satellites, with another nine in-orbit spares and six on-ground spares. These satellites will incorporate features such as data transmission that were not emphasized in the original design. The constellation will provide L-band data speeds of up to 128 kbit/s to mobile terminals, up to 1.5 Mbit/s to Iridium Pilot marine terminals, and high-speed Ka-band service of up to 8 Mbit/s to fixed/transportable terminals. The next-generation terminals and service are expected to be commercially available by the end of 2018. However, Iridium's proposed use of its next-generation satellites has raised concerns the service will harmfully interfere with GPS devices. The satellites will incorporate a secondary payload for Aireon, a space-qualified ADS-B data receiver. This is for use by air traffic control and, via FlightAware, for use by airlines. A tertiary payload on 58 satellites is a marine AIS ship-tracker receiver, for Canadian company exactEarth Ltd. Iridium can also be used to provide a data link to other satellites in space, enabling command and control of other space assets regardless of the position of ground stations and gateways.", null, "Iridium NEXT", null, null },
                    { new Guid("55e3e34d-7277-44e5-b87e-5ff311e1285d"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3170), "Orbcomm Generation 2 (OG2) second-generation satellites are intended to supplement and eventually replace the current first generation constellation. Eighteen satellites were ordered by 2008—nominally intended to be launched in three groups of six during 2010–2014—and by 2015 have all been launched, on three flights. Orbcomm has options for a further thirty OG2 spacecraft. The satellites were launched by SpaceX on the Falcon 9 launch system. Originally, they were to launch on the smaller Falcon 1e rocket.", null, "Orbcomm OG2", null, null },
                    { new Guid("5c29e952-5c73-4d00-b2c6-ad772aad5e8e"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3069), "Thaicom is the name of a series of communications satellites operated from Thailand, and also the name of Thaicom Public Company Limited, which is the company that owns and operates the Thaicom satellite fleet and other telecommunication businesses in Thailand and throughout the Asia-Pacific region. The satellite projects were named Thaicom by the King of Thailand, His Majesty the King Bhumibol Adulyadej, as a symbol of the linkage between Thailand and modern communications technology.", null, "Thaicom", null, null },
                    { new Guid("87595c88-9e5f-47a9-a29e-b24ac7a66d64"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3146), "SES S.A. is a communications satellite owner and operator providing video and data connectivity worldwide to broadcasters, content and internet service providers, mobile and fixed network operators, governments and institutions, with a mission to “connect, enable, and enrich”. SES operates more than 50 geostationary orbit satellites and 16 medium Earth orbit satellites. These comprise the well-known European Astra TV satellites, the O3b data satellites and others with names including AMC, Ciel, NSS, Quetzsat, YahSat and SES.", null, "SES", null, null },
                    { new Guid("c8925134-35e6-4768-8a2f-fcf0512d3864"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3140), "Commercial Resupply Services (CRS) are a series of contracts awarded by NASA from 2008–2016 for delivery of cargo and supplies to the International Space Station (ISS) on commercially operated spacecraft. The first CRS contracts were signed in 2008 and awarded $1.6 billion to SpaceX for 12 cargo transport missions and $1.9 billion to Orbital Sciences for 8 missions, covering deliveries to 2016. In 2015, NASA extended the Phase 1 contracts by ordering an additional three resupply flights from SpaceX and one from Orbital Sciences. After additional extensions late in 2015, SpaceX is currently scheduled to have a total of 20 missions and Orbital 10. SpaceX began flying resupply missions in 2012, using Dragon cargo spacecraft launched on Falcon 9 rockets from Space Launch Complex 40 at Cape Canaveral Air Force Station, Cape Canaveral, Florida. Orbital Sciences began deliveries in 2013 using Cygnus spacecraft launched on the Antares rocket from Launch Pad 0A at the Mid-Atlantic Regional Spaceport (MARS), Wallops Island, Virginia. A second phase of contracts (known as CRS2) were solicited and proposed in 2014. They were awarded in January 2016 to Orbital ATK, Sierra Nevada Corporation, and SpaceX, for cargo transport flights beginning in 2019 and expected to last through 2024.", null, "Commercial Resupply Services", null, null },
                    { new Guid("d2844205-89d0-47db-bbf6-d49e990ff2df"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3157), "Asia Satellite Telecommunications Holdings Limited known as its brand name AsiaSat is a commercial operator of communication spacecraft. AsiaSat is based in Hong Kong but incorporated in Bermuda.", null, "AsiaSat", null, null },
                    { new Guid("ff6b6ad9-442d-4f22-8ae6-44e957a46561"), new Guid("64232849-e64d-4ba2-a036-e6f603dfa182"), new DateTime(2021, 11, 29, 15, 2, 2, 892, DateTimeKind.Local).AddTicks(3177), "ABS, formerly Asia Broadcast Satellite, is a global satellite operator based in Hong Kong and officially incorporated in Bermuda. Its services include direct-to-home and satellite-to-cable TV distribution, cellular services, and internet services. Operating 6 communication satellites, the satellite fleet currently covers 93% of the world’s population including the Americas, Africa, Asia Pacific, Europe, the Middle East, Russia and Commonwealth of Independent States.", null, "ABS", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentCode",
                table: "Employee",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedByEmployeeId",
                table: "Project",
                column: "CreatedByEmployeeId");
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
