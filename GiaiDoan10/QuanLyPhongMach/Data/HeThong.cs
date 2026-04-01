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
    public static class HeThong
    {
        // Biến này sẽ lưu Mã Tài Khoản của người dùng đang đăng nhập vào hệ thống
        public static int MaTaiKhoanHienTai { get; set; } = 0;
    }
}
