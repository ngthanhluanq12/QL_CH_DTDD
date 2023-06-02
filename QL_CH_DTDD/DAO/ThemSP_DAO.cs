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
   public class ThemSP_DAO:DB
    {
        SqlConnection _connection = new SqlConnection(ConnectionString());
        // Đọc sản phẩm với ID
        public SanPham GetProductById(int id)
        {
            var sql = "select * from SanPham where SanPhamId=@CatId";
            var command = new SqlCommand(sql, _connection);

            command.Parameters.Add("CatId", SqlDbType.Int).Value = id;
            _connection.Open();
            var reader = command.ExecuteReader();

            SanPham result = null;

            if (reader.Read()) // ORM - Object relational mapping
            {
                var catId = (int)reader["SanPhamId"];
                var catCategoryId = (int)reader["LoaiSanPhamId"];
                var catProductName = (string)reader["TenSanPham"];
                var catPrice = (int)reader["GiaBan"];
                var catAvatar = (string)reader["HinhAnh"];
                var catDescription = (string)reader["MoTa"];
                var catAddDate = (DateTime)reader["NgayNhap"];
                var catNumberProduct = (int)reader["SoLuong"];
                var catCostPrice = (int)reader["GiaVon"];
                var catEndNumber = (int)reader["TonKho"];

                result = new SanPham()
                {
                    sanPhamId = catId,
                    loaiSanPhamId = catCategoryId,
                    tenSanPham = catProductName,
                    giaBan = catPrice,
                    hinhAnh = catAvatar,
                    moTa = catDescription,
                    ngayNhap = catAddDate,
                    soLuong = catNumberProduct,
                    giaVon = catCostPrice,
                    tonKho = catEndNumber
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
                var catId = (int)reader["SanPhamId"];
                var catCategoryId = (int)reader["LoaiSanPhamId"];
                var catProductName = (string)reader["TenSanPham"];
                var catPrice = (int)reader["GiaBan"];
                var catAvatar = (string)reader["HinhAnh"];
                var catDescription = (string)reader["MoTa"];
                var catAddDate = (DateTime)reader["NgayNhap"];
                var catNumberProduct = (int)reader["SoLuong"];
                var catCostPrice = (int)reader["GiaVon"];
                var catEndNumber = (int)reader["TonKho"];

                var cat = new SanPham()
                {
                    sanPhamId = catId,
                    loaiSanPhamId = catCategoryId,
                    tenSanPham = catProductName,
                    giaBan = catPrice,
                    hinhAnh = catAvatar,
                    moTa = catDescription,
                    ngayNhap = catAddDate,
                    soLuong = catNumberProduct,
                    giaVon = catCostPrice,
                    tonKho = catEndNumber
                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }

        // Đọc danh sách category
        public BindingList<LoaiSanPham> GetAllCategories()
        {
            var result = new BindingList<LoaiSanPham>();
            var sql = "select * from LoaiSanPham";
            var command = new SqlCommand(sql, _connection);
            _connection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var catId = (int)reader["LoaiSanPhamId"];
                var catName = (string)reader["TenLoai"];

                var cat = new LoaiSanPham()
                {
                    loaiSanPhamId = catId,
                    tenLoai = catName,
                };
                result.Add(cat);
            }
            reader.Close();
            _connection.Close();
            return result;
        }
        /// <summary>
        /// Cập nhật loại sản phẩm
        /// </summary>
        /// <param name="addted">Thông tin mới cần thêm</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int AddProduct(SanPham addted)
        {
            var sql = "insert into SanPham(loaiSanPhamId, tenSanPham, giaBan, hinhAnh, moTa, ngayNhap, soLuong, giaVon, tonKho)" +
                " values(@LoaiSanPhamId, @TenSanPham, @GiaBan, @HinhAnh, @MoTa, @NgayNhap, @SoLuong, @GiaVon, @TonKho)";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("SanPhamId", SqlDbType.Int).Value = addted.sanPhamId;
            command.Parameters.Add("LoaiSanPhamId", SqlDbType.Int).Value = addted.loaiSanPhamId;
            command.Parameters.Add("TenSanPham", SqlDbType.NVarChar).Value = addted.tenSanPham;
            command.Parameters.Add("GiaBan", SqlDbType.Int).Value = addted.giaBan;
            command.Parameters.Add("HinhAnh", SqlDbType.NVarChar).Value = addted.hinhAnh;
            command.Parameters.Add("MoTa", SqlDbType.NVarChar).Value = addted.moTa;
            command.Parameters.Add("NgayNhap", SqlDbType.DateTime).Value = addted.ngayNhap;
            command.Parameters.Add("SoLuong", SqlDbType.Int).Value = addted.soLuong;
            command.Parameters.Add("GiaVon", SqlDbType.Int).Value = addted.giaVon;
            command.Parameters.Add("TonKho", SqlDbType.Int).Value = addted.tonKho;
            _connection.Open();
            var rowsCount = command.ExecuteNonQuery();
            _connection.Close();
            return rowsCount;
        }
    }
}
