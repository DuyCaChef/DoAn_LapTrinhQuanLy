using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongMach.Migrations
{
    /// <inheritdoc />
    public partial class ThemCotTrieuChung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrieuChung",
                table: "PHIEUKHAM",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrieuChung",
                table: "PHIEUKHAM");
        }
    }
}
