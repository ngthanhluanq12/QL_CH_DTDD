using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DTO
{
    public class NhanVien : ICloneable, INotifyPropertyChanged
    {
        public int nhanVienId { get; set; }
        public string tenNhanVien { get; set; }
        public string soDienThoai { get; set; }
        public string diaChi { get; set; }
        public string email { get; set; }
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }
        public int boPhan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
