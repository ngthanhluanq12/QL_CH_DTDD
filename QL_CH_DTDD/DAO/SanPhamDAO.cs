using QL_CH_DTDD.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CH_DTDD.DAO
{
   public class SanPhamDAO:DB
    {
        SqlConnection _connection = new SqlConnection(ConnectionString());

        public SanPham GetProductById(int id)
        {
            var sql = "select * from SanPham where SanPhamId=@CatSanPhamId";
            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("CatSanPhamId", SqlDbType.Int).Value = id;
            _connection.Open();
            var reader = command.ExecuteReader();

            SanPham result = null;

            if (reader.Read()) // ORM - Object relational mapping
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

                result = new SanPham()
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
            }
            _connection.Close();
            return result;
        }
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
        // tim theo gia
        public BindingList<SanPham> FilterPrice(int star, int end)
        {
            var result = new BindingList<SanPham>();
            var sql = "select * from SanPham where GiaBan between @fromPrice and @toPrice";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@fromPrice", SqlDbType.Int).Value = star;
            command.Parameters.AddWithValue("@toPrice", SqlDbType.Int).Value = end;
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
        // get category
        public BindingList<LoaiSanPham> GetAllCategories()
        {
            var result = new BindingList<LoaiSanPham>();
            var sql = "select * from LoaiSanPham";
            var command = new SqlCommand(sql, _connection);
            _connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var catLoaiSanPhamId = (int)reader["LoaiSanPhamId"];
                var catTenLoai = (string)reader["TenLoai"];
                var catMoTa = (string)reader["MoTa"].ToString();

                var cat = new LoaiSanPham()
                {
                    loaiSanPhamId = catLoaiSanPhamId,
                    tenLoai = catTenLoai,
                    moTa = catMoTa
                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }

    }
}
