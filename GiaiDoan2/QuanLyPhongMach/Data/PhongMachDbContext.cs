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

    }
}
