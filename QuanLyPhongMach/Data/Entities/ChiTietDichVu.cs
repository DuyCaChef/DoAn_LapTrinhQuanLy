using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach.Data.Entities
{
        [Table("CHITIET_DICHVU")]
        public class ChiTietDichVu
        {
            [Key]
            public int MaCTDV { get; set; }

            public int MaPK { get; set; }
            [ForeignKey("MaPK")]
            public virtual PhieuKham PhieuKham { get; set; }

            public int MaDV { get; set; }
            [ForeignKey("MaDV")]
            public virtual DichVu DichVu { get; set; }

            public int SoLuong { get; set; } = 1; // Thường dịch vụ khám/siêu âm số lượng là 1
        }
}
