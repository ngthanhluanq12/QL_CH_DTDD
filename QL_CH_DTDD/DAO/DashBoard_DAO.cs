using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DAO
{
   public class DashBoard_DAO:DB
    {
        SqlConnection _connection = new SqlConnection(ConnectionString());

        // Đọc danh sách sản phẩm
        public BindingList<SanPham> GetAllProduct()
        {
            var result = new BindingList<SanPham>();
            var sql = "select * from SanPham";
            var command = new SqlCommand(sql, _connection);
            _connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var catSanPhamId = (int)reader["SanPhamId"];
                var catLoaiSanPhamId = (int)reader["LoaiSanPhamId"];
                var catTenSanPham = (string)reader["TenSanPham"];
                var catGiaBan = (int)reader["GiaBan"];
                var catHinhAnh = (string)reader["HinhAnh"];
                var catMoTa = (string)reader["MoTa"];
                var catNgayNhap = (DateTime)reader["NgayNhap"];
                var catSoLuong = (int)reader["SoLuong"];
                var catGiaVon = (int)reader["GiaVon"];
                var catTonKho = (int)reader["TonKho"];

                var cat = new SanPham()
                {
                    sanPhamId = catSanPhamId,
                    loaiSanPhamId = catLoaiSanPhamId,
                    tenSanPham = catTenSanPham,
                    giaBan = catGiaBan,
                    hinhAnh = catHinhAnh,
                    moTa = catMoTa,
                    ngayNhap = catNgayNhap,
                    soLuong = catSoLuong,
                    giaVon = catGiaVon,
                    tonKho = catTonKho
                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }
        // loc san pham <5
        public BindingList<SanPham> GetAllProductSmall()
        {
            var result = new BindingList<SanPham>();
            var sql = "select * from SanPham where TonKho < 5 ";
            var command = new SqlCommand(sql, _connection);
            _connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var catSanPhamId = (int)reader["SanPhamId"];
                var catLoaiSanPhamId = (int)reader["LoaiSanPhamId"];
                var catTenSanPham = (string)reader["TenSanPham"];
                var catGiaBan = (int)reader["GiaBan"];
                var catHinhAnh = (string)reader["HinhAnh"];
                var catMoTa = (string)reader["MoTa"];
                var catNgayNhap = (DateTime)reader["NgayNhap"];
                var catSoLuong = (int)reader["SoLuong"];
                var catGiaVon = (int)reader["GiaVon"];
                var catTonKho = (int)reader["TonKho"];

                var cat = new SanPham()
                {
                    sanPhamId = catSanPhamId,
                    loaiSanPhamId = catLoaiSanPhamId,
                    tenSanPham = catTenSanPham,
                    giaBan = catGiaBan,
                    hinhAnh = catHinhAnh,
                    moTa = catMoTa,
                    ngayNhap = catNgayNhap,
                    soLuong = catSoLuong,
                    giaVon = catGiaVon,
                    tonKho = catTonKho
                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }
        // Đọc danh sách hoa don
        public BindingList<DonHang> GetAllCustomBill()
        {
            var result = new BindingList<DonHang>();
            var sql = "select * from DonHang";
            var command = new SqlCommand(sql, _connection);
            _connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var catId = (int)reader["id"];
                var catLoaiSanPhamId = (int)reader["LoaiSanPhamId"];
                var catSanPhamId = (int)reader["SanPhamId"];
                var catTenKhachHang = (string)reader["TenKhachHang"];
                var CatTenSanPham = (string)reader["TenSanPham"];
                var catNgayBan = (DateTime)reader["NgayBan"];
                var catDienThoai = (string)reader["DienThoai"];
                var catDiaChi = (string)reader["DiaChi"];
                var catSoLuongMua = (int)reader["SoLuongMua"];
                var catGiaBan = (int)reader["GiaBan"];
                var catTongTien = (int)reader["TongTien"];
                var catTienKhachDua = (int)reader["TienKhachDua"];
                var catTienThoiLai = (int)reader["TienThoiLai"];
                var catLoiNhuan = (int)reader["LoiNhuan"];


                var cat = new DonHang()
                {
                    ID = catId,
                    loaiSanPhamId = catLoaiSanPhamId,
                    sanPhamId = catSanPhamId,
                    tenKhachHang = catTenKhachHang,
                    tenSanPham = CatTenSanPham,
                    ngayBan = catNgayBan,
                    dienThoai = catDienThoai,
                    diaChi = catDiaChi,
                    soLuongMua = catSoLuongMua,
                    giaBan = catGiaBan,
                    tongTien = catTongTien,
                    tienKhachDua = catTienKhachDua,
                    tienThoiLai = catTienThoiLai,
                    loiNhuan = catLoiNhuan


                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }
    }
}
