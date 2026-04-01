using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongMach.Migrations
{
    /// <inheritdoc />
    public partial class ThemTrangThaiChoLichKham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "LICHKHAM",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LICHKHAM");
        }
    }
}
