using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("THUOC")]
    public class Thuoc
    {
        [Key]
        public int MaThuoc { get; set; }

        [Required, StringLength(200)]
        public string TenThuoc { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; } // Viên, Vỉ, Hộp, Chai...

        // [THÊM MỚI] Khai báo định dạng tiền tệ (18 chữ số, 0 phần thập phân cho VNĐ)
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGia { get; set; }
    }
}
