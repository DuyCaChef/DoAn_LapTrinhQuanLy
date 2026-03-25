using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("KHACHHANG")]
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [Required]
        public int MaTK { get; set; }

        [Required]
        [StringLength(100)]
        public string TenKH { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [ForeignKey("MaTK")]
        public TaiKhoan TaiKhoan { get; set; }

        public ICollection<LichKham> LichKhams { get; set; }

    }
}
