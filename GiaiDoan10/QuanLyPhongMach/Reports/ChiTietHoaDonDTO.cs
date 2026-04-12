using System;

namespace QuanLyPhongMach.Reports
{
    // Class này như một "cái rổ" để gom chung cả Thuốc và Dịch vụ thành 1 danh sách
    public class ChiTietHoaDonDTO
    {
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}