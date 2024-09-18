using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_MVC_App.Migrations
{
    /// <inheritdoc />
    public partial class StatusName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StuStatus",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "DeptStatus",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StuStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeptStatus",
                table: "Departments");
        }
    }
}
