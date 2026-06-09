using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldToMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Members",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Members");
        }
    }
}
