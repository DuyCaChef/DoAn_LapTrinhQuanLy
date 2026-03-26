using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongMach.Migrations
{
    /// <inheritdoc />
    public partial class ThemThuocVaDichVu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DICHVU",
                columns: table => new
                {
                    MaDV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDichVu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DICHVU", x => x.MaDV);
                });

            migrationBuilder.CreateTable(
                name: "THUOC",
                columns: table => new
                {
                    MaThuoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuoc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUOC", x => x.MaThuoc);
                });

            migrationBuilder.CreateTable(
                name: "CHITIET_DICHVU",
                columns: table => new
                {
                    MaCTDV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPK = table.Column<int>(type: "int", nullable: false),
                    MaDV = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIET_DICHVU", x => x.MaCTDV);
                    table.ForeignKey(
                        name: "FK_CHITIET_DICHVU_DICHVU_MaDV",
                        column: x => x.MaDV,
                        principalTable: "DICHVU",
                        principalColumn: "MaDV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIET_DICHVU_PHIEUKHAM_MaPK",
                        column: x => x.MaPK,
                        principalTable: "PHIEUKHAM",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHITIET_DONTHUOC",
                columns: table => new
                {
                    MaCTDT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPK = table.Column<int>(type: "int", nullable: false),
                    MaThuoc = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    CachDung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIET_DONTHUOC", x => x.MaCTDT);
                    table.ForeignKey(
                        name: "FK_CHITIET_DONTHUOC_PHIEUKHAM_MaPK",
                        column: x => x.MaPK,
                        principalTable: "PHIEUKHAM",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHITIET_DONTHUOC_THUOC_MaThuoc",
                        column: x => x.MaThuoc,
                        principalTable: "THUOC",
                        principalColumn: "MaThuoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIET_DICHVU_MaDV",
                table: "CHITIET_DICHVU",
                column: "MaDV");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIET_DICHVU_MaPK",
                table: "CHITIET_DICHVU",
                column: "MaPK");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIET_DONTHUOC_MaPK",
                table: "CHITIET_DONTHUOC",
                column: "MaPK");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIET_DONTHUOC_MaThuoc",
                table: "CHITIET_DONTHUOC",
                column: "MaThuoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIET_DICHVU");

            migrationBuilder.DropTable(
                name: "CHITIET_DONTHUOC");

            migrationBuilder.DropTable(
                name: "DICHVU");

            migrationBuilder.DropTable(
                name: "THUOC");
        }
    }
}
