using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hospital.Migrations
{
    public partial class lol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SVNR = table.Column<int>(type: "int", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    SALARY = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.EMPLOYEE_ID);
                });

            migrationBuilder.CreateTable(
                name: "HOSPITAL_FACILITIES",
                columns: table => new
                {
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PHONE_NR = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOSPITAL_FACILITIES", x => x.FACILITY_ID);
                });

            migrationBuilder.CreateTable(
                name: "CARETAKER",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SUPERIOR_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARETAKER", x => x.EMPLOYEE_ID);
                    table.ForeignKey(
                        name: "FK_CARETAKER_CARETAKER_SUPERIOR_ID",
                        column: x => x.SUPERIOR_ID,
                        principalTable: "CARETAKER",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARETAKER_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHYSICANS",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JOB_SPECIFICATION = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHYSICANS", x => x.EMPLOYEE_ID);
                    table.ForeignKey(
                        name: "FK_PHYSICANS_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WARDS",
                columns: table => new
                {
                    WARD_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CARRING_CAPACITY = table.Column<int>(type: "INT", nullable: false),
                    MANAGER_ID = table.Column<int>(type: "int", nullable: true),
                    FACILITY_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WARDS", x => x.WARD_ID);
                    table.ForeignKey(
                        name: "FK_WARDS_HOSPITAL_FACILITIES_FACILITY_ID",
                        column: x => x.FACILITY_ID,
                        principalTable: "HOSPITAL_FACILITIES",
                        principalColumn: "FACILITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WARDS_PHYSICANS_MANAGER_ID",
                        column: x => x.MANAGER_ID,
                        principalTable: "PHYSICANS",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OCCUPATIONS",
                columns: table => new
                {
                    WARD_ID = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false),
                    WORKING_HOURS = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCCUPATIONS", x => new { x.EMPLOYEE_ID, x.WARD_ID });
                    table.ForeignKey(
                        name: "FK_OCCUPATIONS_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OCCUPATIONS_WARDS_WARD_ID",
                        column: x => x.WARD_ID,
                        principalTable: "WARDS",
                        principalColumn: "WARD_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARETAKER_SUPERIOR_ID",
                table: "CARETAKER",
                column: "SUPERIOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_SVNR",
                table: "EMPLOYEES",
                column: "SVNR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOSPITAL_FACILITIES_NAME",
                table: "HOSPITAL_FACILITIES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HOSPITAL_FACILITIES_PHONE_NR",
                table: "HOSPITAL_FACILITIES",
                column: "PHONE_NR",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OCCUPATIONS_WARD_ID",
                table: "OCCUPATIONS",
                column: "WARD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WARDS_FACILITY_ID",
                table: "WARDS",
                column: "FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WARDS_MANAGER_ID",
                table: "WARDS",
                column: "MANAGER_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARETAKER");

            migrationBuilder.DropTable(
                name: "OCCUPATIONS");

            migrationBuilder.DropTable(
                name: "WARDS");

            migrationBuilder.DropTable(
                name: "HOSPITAL_FACILITIES");

            migrationBuilder.DropTable(
                name: "PHYSICANS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");
        }
    }
}
