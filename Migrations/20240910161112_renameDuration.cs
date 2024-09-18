using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_MVC_App.Migrations
{
    /// <inheritdoc />
    public partial class renameDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deuration",
                table: "Courses",
                newName: "Duration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Courses",
                newName: "Deuration");
        }
    }
}
