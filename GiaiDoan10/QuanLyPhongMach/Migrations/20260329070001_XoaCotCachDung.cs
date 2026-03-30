using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongMach.Migrations
{
    /// <inheritdoc />
    public partial class XoaCotCachDung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CachDung",
                table: "CHITIET_DONTHUOC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CachDung",
                table: "CHITIET_DONTHUOC",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
