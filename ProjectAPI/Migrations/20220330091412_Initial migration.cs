using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    Titel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoursWorked = table.Column<double>(nullable: false),
                    WeekNumber = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FName", "LName", "Titel" },
                values: new object[,]
                {
                    { 1, "Viktor", "Gunnarsson", "Utvecklare" },
                    { 2, "Erik", "Norell", "Utvecklare" },
                    { 3, "Lukas", "Rose", "Utvecklare" },
                    { 4, "Erik", "Risholm", "Utvecklare" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectName" },
                values: new object[,]
                {
                    { 1, "Desktop Application" },
                    { 2, "Rest Api" },
                    { 3, "Mobile Application" },
                    { 4, "Presentation" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "Id", "EmployeeId", "HoursWorked", "ProjectId", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1, 40.200000000000003, 1, 12 },
                    { 2, 1, 10.199999999999999, 2, 12 },
                    { 5, 2, 40.200000000000003, 2, 12 },
                    { 3, 3, 10.5, 3, 12 },
                    { 6, 2, 10.0, 3, 12 },
                    { 4, 1, 12.0, 4, 12 },
                    { 7, 4, 45.0, 4, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
