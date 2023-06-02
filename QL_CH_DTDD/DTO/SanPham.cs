using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DTO
{
   public class SanPham : ICloneable, INotifyPropertyChanged
    {
        public int sanPhamId { get; set; }
        public int loaiSanPhamId { get; set; }
        public string tenSanPham { get; set; }
        public int giaBan { get; set; }
        public string hinhAnh { get; set; }
        public string moTa { get; set; }
        public System.DateTime ngayNhap { get; set; }
        public int soLuong { get; set; }
        public int giaVon { get; set; }
        public int tonKho { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
