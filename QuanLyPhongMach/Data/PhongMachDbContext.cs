using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuanLyPhongMach.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QuanLyPhongMach.Data
{
    public class PhongMachDbContext : DbContext
    {
        //TÀI KHOẢN VÀ NHÂN SỰ
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<BacSi> BacSis { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }

        //NGHIỆP VỤ PHÒNG MẠCH
        public DbSet<LichKham> LichKhams { get; set; }
        public DbSet<PhieuKham> PhieuKhams { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }

        //NHẬT KÝ HỆ THỐNG
        public DbSet<NhatKyHeThong> NhatKyHeThongs { get; set; }

        //THUỐC VÀ DỊCH VỤ
        public DbSet<Thuoc> Thuocs { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
        public DbSet<ChiTietDichVu> ChiTietDichVus { get; set; }


        //CẤU HÌNH BỔ SUNG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["PhongMachDbContext"].ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // LICHKHAM -> KHACHHANG (KHÔNG CASCADE)
            modelBuilder.Entity<LichKham>()
                .HasOne(lk => lk.KhachHang)
                .WithMany(kh => kh.LichKhams)
                .HasForeignKey(lk => lk.MaKH)
                .OnDelete(DeleteBehavior.Restrict);

            // LICHKHAM -> BACSI (KHÔNG CASCADE)
            modelBuilder.Entity<LichKham>()
                .HasOne(lk => lk.BacSi)
                .WithMany(bs => bs.LichKhams)
                .HasForeignKey(lk => lk.MaBS)
                .OnDelete(DeleteBehavior.Restrict);
        }

        // =========================================================================
        // GHI ĐÈ HÀM SAVECHANGES ĐỂ TỰ ĐỘNG GHI LOG CHI TIẾT
        // =========================================================================
        public override int SaveChanges()
        {
            // 1. Quét tất cả các đối tượng đang có sự thay đổi (Thêm, Sửa, Xóa)
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in modifiedEntries)
            {
                // Bỏ qua không ghi log cho bảng Log để tránh lặp vô tận
                if (entry.Entity is NhatKyHeThong)
                    continue;

                string tenBang = entry.Entity.GetType().Name;
                string hanhDong = "";
                string moTa = "";

                switch (entry.State)
                {
                    case EntityState.Added:
                        hanhDong = "Thêm mới";
                        moTa = $"Thêm mới dữ liệu vào bảng {tenBang}";
                        break;

                    case EntityState.Modified:
                        hanhDong = "Cập nhật";
                        // Dò tìm xem cụ thể cột nào bị sửa
                        var danhSachThayDoi = new List<string>();
                        foreach (var prop in entry.Properties)
                        {
                            if (prop.IsModified)
                            {
                                string giaTriCu = prop.OriginalValue?.ToString() ?? "Trống";
                                string giaTriMoi = prop.CurrentValue?.ToString() ?? "Trống";

                                if (giaTriCu != giaTriMoi)
                                {
                                    danhSachThayDoi.Add($"{prop.Metadata.Name}: '{giaTriCu}' -> '{giaTriMoi}'");
                                }
                            }
                        }
                        moTa = $"Sửa {tenBang} | " + string.Join(", ", danhSachThayDoi);
                        break;

                    case EntityState.Deleted:
                        hanhDong = "Xóa";
                        moTa = $"Xóa dữ liệu khỏi bảng {tenBang}";
                        break;
                }

                // Cắt ngắn chuỗi tránh lỗi SQL (giới hạn 255 ký tự)
                if (moTa.Length > 255)
                {
                    moTa = moTa.Substring(0, 252) + "...";
                }

                // ========================================================
                // [ÁO GIÁP CHỐNG LỖI KHÓA NGOẠI TỰ ĐỘNG]
                // ========================================================
                int maNguoiDung = HeThong.MaTaiKhoanHienTai;

                // Kiểm tra xem ID này có thực sự tồn tại trong DB không
                if (!this.TaiKhoans.Any(tk => tk.MaTK == maNguoiDung))
                {
                    // Nếu ID không hợp lệ (ví dụ Admin ảo đăng nhập), tự lấy TK đầu tiên làm thế thân
                    var userThayThe = this.TaiKhoans.FirstOrDefault();
                    if (userThayThe != null)
                    {
                        maNguoiDung = userThayThe.MaTK;
                        moTa = "[Admin Ảo] " + moTa; // Đánh dấu để biết đây là hệ thống tự lấy
                    }
                }

                // Khởi tạo dòng Log
                var log = new NhatKyHeThong
                {
                    MaTK = maNguoiDung, // Đã dùng ID an toàn tuyệt đối
                    ThoiGian = DateTime.Now,
                    HanhDong = hanhDong,
                    BangTacDong = tenBang,
                    MoTa = moTa
                };

                this.NhatKyHeThongs.Add(log);
            }

            // Gọi hàm Save gốc để lưu dữ liệu thực tế VÀ dòng Log xuống SQL Server
            return base.SaveChanges();
        }
    }
}
