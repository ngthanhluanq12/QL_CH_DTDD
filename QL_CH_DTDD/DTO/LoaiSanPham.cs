using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DTO
{
   public class LoaiSanPham : ICloneable, INotifyPropertyChanged
    {
        public int loaiSanPhamId { get; set; }
        public string tenLoai { get; set; }
        public string moTa { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
