using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyPhongMach.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTaoCSDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    MaTK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhauHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOAN", x => x.MaTK);
                });

            migrationBuilder.CreateTable(
                name: "BACSI",
                columns: table => new
                {
                    MaBS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTK = table.Column<int>(type: "int", nullable: false),
                    TenBS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChuyenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BACSI", x => x.MaBS);
                    table.ForeignKey(
                        name: "FK_BACSI_TAIKHOAN_MaTK",
                        column: x => x.MaTK,
                        principalTable: "TAIKHOAN",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTK = table.Column<int>(type: "int", nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACHHANG", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_KHACHHANG_TAIKHOAN_MaTK",
                        column: x => x.MaTK,
                        principalTable: "TAIKHOAN",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTK = table.Column<int>(type: "int", nullable: false),
                    TenNV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIEN", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NHANVIEN_TAIKHOAN_MaTK",
                        column: x => x.MaTK,
                        principalTable: "TAIKHOAN",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NHATKYHETHONG",
                columns: table => new
                {
                    MaLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTK = table.Column<int>(type: "int", nullable: false),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HanhDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BangTacDong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaDoiTuong = table.Column<int>(type: "int", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHATKYHETHONG", x => x.MaLog);
                    table.ForeignKey(
                        name: "FK_NHATKYHETHONG_TAIKHOAN_MaTK",
                        column: x => x.MaTK,
                        principalTable: "TAIKHOAN",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LICHKHAM",
                columns: table => new
                {
                    MaLichKham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    MaBS = table.Column<int>(type: "int", nullable: false),
                    NgayKham = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioKham = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LICHKHAM", x => x.MaLichKham);
                    table.ForeignKey(
                        name: "FK_LICHKHAM_BACSI_MaBS",
                        column: x => x.MaBS,
                        principalTable: "BACSI",
                        principalColumn: "MaBS",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LICHKHAM_KHACHHANG_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUKHAM",
                columns: table => new
                {
                    MaPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLichKham = table.Column<int>(type: "int", nullable: false),
                    ChanDoan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoiDan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUKHAM", x => x.MaPK);
                    table.ForeignKey(
                        name: "FK_PHIEUKHAM_LICHKHAM_MaLichKham",
                        column: x => x.MaLichKham,
                        principalTable: "LICHKHAM",
                        principalColumn: "MaLichKham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPK = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThaiThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADON", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HOADON_PHIEUKHAM_MaPK",
                        column: x => x.MaPK,
                        principalTable: "PHIEUKHAM",
                        principalColumn: "MaPK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BACSI_MaTK",
                table: "BACSI",
                column: "MaTK");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaPK",
                table: "HOADON",
                column: "MaPK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KHACHHANG_MaTK",
                table: "KHACHHANG",
                column: "MaTK");

            migrationBuilder.CreateIndex(
                name: "IX_LICHKHAM_MaBS",
                table: "LICHKHAM",
                column: "MaBS");

            migrationBuilder.CreateIndex(
                name: "IX_LICHKHAM_MaKH",
                table: "LICHKHAM",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_MaTK",
                table: "NHANVIEN",
                column: "MaTK");

            migrationBuilder.CreateIndex(
                name: "IX_NHATKYHETHONG_MaTK",
                table: "NHATKYHETHONG",
                column: "MaTK");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUKHAM_MaLichKham",
                table: "PHIEUKHAM",
                column: "MaLichKham",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "NHATKYHETHONG");

            migrationBuilder.DropTable(
                name: "PHIEUKHAM");

            migrationBuilder.DropTable(
                name: "LICHKHAM");

            migrationBuilder.DropTable(
                name: "BACSI");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");
        }
    }
}
