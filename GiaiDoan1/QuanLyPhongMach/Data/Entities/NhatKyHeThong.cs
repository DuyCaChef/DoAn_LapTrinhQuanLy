using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("NHATKYHETHONG")]
    public class NhatKyHeThong
    {
        [Key]
        public int MaLog{ get; set; }

        [Required]
        public int MaTK { get; set; }

        public DateTime ThoiGian { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string HanhDong { get; set; }

        [StringLength(100)]
        public string BangTacDong { get; set; } 
            
        public int? MaDoiTuong { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        [ForeignKey("MaTK")]
        public TaiKhoan TaiKhoan { get; set; }  
    }
}
