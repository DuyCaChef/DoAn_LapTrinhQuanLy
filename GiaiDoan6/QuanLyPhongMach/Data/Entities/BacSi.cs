using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("BACSI")]
    public class BacSi
    {
        [Key]
        public int MaBS { get; set; }

        [Required]
        public int MaTK { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBS { get; set; }

        [Required]
        [StringLength(100)]
        public string ChuyenKhoa { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        public ICollection<LichKham> LichKhams { get; set; }

        [ForeignKey("MaTK")]
        public TaiKhoan TaiKhoan { get; set; }
    }
}
