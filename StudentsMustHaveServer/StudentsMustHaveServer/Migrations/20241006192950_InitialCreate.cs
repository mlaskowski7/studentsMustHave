using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsMustHaveServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Techs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Student_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Student_ID1 = table.Column<int>(type: "int", nullable: false),
                    Subject_ID = table.Column<int>(type: "int", nullable: false),
                    Subject_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Homeworks_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Homeworks_Subjects_Subject_ID1",
                        column: x => x.Subject_ID1,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tech_ID = table.Column<int>(type: "int", nullable: false),
                    Tech_ID1 = table.Column<int>(type: "int", nullable: false),
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Student_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Skills_Students_Student_ID1",
                        column: x => x.Student_ID1,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_Techs_Tech_ID1",
                        column: x => x.Tech_ID1,
                        principalTable: "Techs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechs",
                columns: table => new
                {
                    Project_ID = table.Column<int>(type: "int", nullable: false),
                    Tech_ID = table.Column<int>(type: "int", nullable: false),
                    Project_ID1 = table.Column<int>(type: "int", nullable: false),
                    Tech_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechs", x => new { x.Project_ID, x.Tech_ID });
                    table.ForeignKey(
                        name: "FK_ProjectTechs_Projects_Project_ID",
                        column: x => x.Project_ID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechs_Techs_Tech_ID",
                        column: x => x.Tech_ID,
                        principalTable: "Techs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_Student_ID1",
                table: "Homeworks",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_Subject_ID1",
                table: "Homeworks",
                column: "Subject_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Student_ID1",
                table: "Projects",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechs_Tech_ID",
                table: "ProjectTechs",
                column: "Tech_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Student_ID1",
                table: "Skills",
                column: "Student_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Tech_ID1",
                table: "Skills",
                column: "Tech_ID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "ProjectTechs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Techs");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
