using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("DICHVU")]
    public class DichVu
    {
        [Key]
        public int MaDV { get; set; }

        [Required, StringLength(200)]
        public string TenDichVu { get; set; } // Khám bệnh, Siêu âm, X-Quang...

        // [THÊM MỚI] Khai báo định dạng tiền tệ
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGia { get; set; }
    }
}
