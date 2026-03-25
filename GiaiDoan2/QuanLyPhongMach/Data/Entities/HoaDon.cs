using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("HOADON")]
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }

        [Required]
        public int MaPK { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [StringLength(50)]
        public string TrangThaiThanhToan { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        [ForeignKey("MaPK")]
        public PhieuKham PhieuKham { get; set; }
    }
}
