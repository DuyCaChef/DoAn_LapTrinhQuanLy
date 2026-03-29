using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
    [Table("CHITIET_DONTHUOC")]
    public class ChiTietDonThuoc
    {
        [Key]
        public int MaCTDT { get; set; }

        public int MaPK { get; set; }
        [ForeignKey("MaPK")]
        public virtual PhieuKham PhieuKham { get; set; }

        public int MaThuoc { get; set; }
        [ForeignKey("MaThuoc")]
        public virtual Thuoc Thuoc { get; set; }

        public int SoLuong { get; set; }
    }
}
