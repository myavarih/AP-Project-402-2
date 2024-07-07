using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP_Project.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSolved",
                table: "Complaints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSolved",
                table: "Complaints",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
