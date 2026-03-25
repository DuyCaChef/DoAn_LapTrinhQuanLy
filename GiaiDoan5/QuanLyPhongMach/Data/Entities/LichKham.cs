using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("LICHKHAM")]
    public class LichKham
    {
        [Key]
        public int MaLichKham { get; set; }

        [Required]
        public int MaKH { get; set; }

        [Required]  
        public int MaBS { get; set; }

        [Required]
        public DateTime NgayKham { get; set; }

        [Required]
        public TimeSpan GioKham { get; set; }

        [ForeignKey("MaKH")]
        public KhachHang KhachHang { get; set; }    

        [ForeignKey("MaBS")]
        public BacSi BacSi { get; set; }

        public PhieuKham PhieuKham { get; set; }

        public string TrangThai { get; set; }

    }
}
