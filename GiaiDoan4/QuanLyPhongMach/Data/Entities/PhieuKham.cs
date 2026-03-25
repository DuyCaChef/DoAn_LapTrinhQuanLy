using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("PHIEUKHAM")]
    public class PhieuKham
    {
        [Key]
        public int MaPK { get; set; }

        [Required]
        public int MaLichKham { get; set; }

        [StringLength(500)]
        public string TrieuChung { get; set; }

        [StringLength(500)]
        public string ChanDoan { get; set; }

        [StringLength(500)]
        public string LoiDan { get; set; }

        public DateTime NgayLap { get; set; } = DateTime.Now;

        [ForeignKey("MaLichKham")]
        public LichKham LichKham { get; set; }

        public HoaDon HoaDon { get; set; }

        public virtual ICollection<ChiTietDonThuoc> ChiTietDonThuocs { get; set; }
        public virtual ICollection<ChiTietDichVu> ChiTietDichVus { get; set; }
    }
}
