using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DTO
{
    public class DonHang : ICloneable, INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int loaiSanPhamId { get; set; }
        public int sanPhamId { get; set; }
        public string tenKhachHang { get; set; }
        public string tenSanPham { get; set; }
        public System.DateTime ngayBan { get; set; }
        public string dienThoai { get; set; }
        public string diaChi { get; set; }
        public int soLuongMua { get; set; }
        public int giaBan { get; set; }
        public int tongTien { get; set; }
        public int tienKhachDua { get; set; }
        public int tienThoiLai { get; set; }
        public int loiNhuan { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
